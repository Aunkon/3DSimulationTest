using UnityEngine;

public class CommonEscapeManager : MonoBehaviour
{
    #region Unity Methods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    #endregion Unity Methods
}
