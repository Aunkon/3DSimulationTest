using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointConnection : MonoBehaviour
{
    public GameObject startNode;
    public Vector3 endPosition;

    public bool isActive = true;
    private bool disbleCreation = false;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (disbleCreation)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                endPosition = hit.point;
            }
            Debug.Log(endPosition);
            if (hit.transform.tag == "Node" && hit.transform.gameObject != startNode)
            {
                GetComponent<Edge>().endNode = hit.transform.gameObject;
                disbleCreation = true;
                GetComponent<Edge>().enabled = true;
                ConnectorGenerator.canSpawnConnector = true;
                GetComponent<Edge>().isActive = true;
                isActive = false;
            }
            Resize();
        }
    }

    private void Resize()
    {
        float distance = Vector3.Distance(startNode.transform.position, endPosition);
        transform.localScale = new Vector3(0.25f, 0.25f, distance);

        Vector3 middlePoint = (startNode.transform.position + endPosition) / 2;
        transform.position = middlePoint;

        Vector3 rotationDirection = (endPosition - startNode.transform.position);
        transform.rotation = Quaternion.LookRotation(rotationDirection);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!isActive)
    //    {
    //        return;
    //    }

    //    if (collision.gameObject.tag == "Node" && collision.gameObject != startNode)
    //    {
    //        GetComponent<Edge>().endNode = collision.gameObject;
    //        disbleCreation = true;
    //        GetComponent<Edge>().enabled = true;
    //        ConnectorGenerator.canSpawnConnector = true;
    //        isActive = false;
    //    }
    //}
}
