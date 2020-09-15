using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


[Serializable]
public class ResponseJsonClass
{
    public int boxes;
}

public class GetChildsFromIdare : MonoBehaviour
{

    public string apiEndpoint;
    public GameObject _loadingBar, _errorPopUp;
    public Text _errorDetails;
    public ResponseJsonClass responseJsonObj;
    public string responseString;
    public Text resultText;
    public NodeGeneration nodeGeneration;


    #region Unity Default Methods
    private void Awake()
    {
        GetData();
    }
    #endregion Unity Default Methods

    #region Public Methods
    public void GetData()
    {
        try
        {
            StartCoroutine(GetFromAPI());
        }
        catch (Exception exception)
        {
            Debug.LogWarning(exception);
        }
    }
    #endregion Public Methods

    #region Private Methods
    private IEnumerator GetFromAPI()
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(string.Format("{0}?name={1}", apiEndpoint, "idare")))
        {
            _loadingBar.SetActive(true);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                _errorPopUp.SetActive(true);
                string error = uwr.error;
                
                //trying to understand which error occurced.
                if (error.Contains("400"))
                {
                    error = string.Format("Server cannot proccess your request!");
                }
                else if (error.Contains("401"))
                {
                    error = string.Format("Incorrect Username or Password!");
                }
                else if (error.Contains("403"))
                {
                    error = string.Format("Token verification error!");
                }
                else if (error.Contains("404"))
                {
                    error = string.Format("The Server connection not Found!");
                }
                else if (error.Contains("408"))
                {
                    error = string.Format("Request Time out, Internet Connection is so poor!");
                }
                else if (error.Contains("Cannot connect"))
                {
                    error = string.Format("No internet connection or The connection is so poor!");
                }
                else if (error.Contains("Cannot resolve"))
                {
                    error = string.Format("No internet connection or the connection is so poor!");
                }
                else
                {
                    error = uwr.error;
                }
                _errorDetails.text = error;
            }
            else if (uwr.isDone)
            {
                try
                {
                    responseString = Encoding.UTF8.GetString(uwr.downloadHandler.data);

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        responseJsonObj = JsonUtility.FromJson<ResponseJsonClass>(responseString);
                        resultText.text = responseString;
                        nodeGeneration.GenerateNodes(responseJsonObj.boxes);
                    }
                    else
                    {
                        _errorPopUp.SetActive(true);
                        _errorDetails.text = string.Format("Unfortunately an Unknown error Occurred!");
                    }
                }
                catch (Exception exception)
                {
                    _errorPopUp.SetActive(true);
                    _errorDetails.text = exception.ToString();
                }
            }
            else
            {
                Debug.LogError("Unfortunately an Unknown error Occurred!");
            }
            _loadingBar.SetActive(false);
            uwr.Dispose();
        }
    }
    #endregion  Private Methods
}