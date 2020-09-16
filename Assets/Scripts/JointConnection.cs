using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                Edge currentEdge = GetComponent<Edge>();
                currentEdge.endNode = hit.transform.gameObject;
                currentEdge.enabled = true;
                currentEdge.isActive = true;
                currentEdge.edgeName =
                    string.Format(
                        "{0}N{1}",
                        startNode.name,
                        hit.transform.name
                        );
                ConnectorGenerator.canSpawnConnector = true;
                CheckEdgeExistOrNot(currentEdge);
                disbleCreation = true;
                isActive = false;
            }
            Resize();
        }
    }

    private void CheckEdgeExistOrNot(Edge currentEdge)
    {
        int length = NodeGeneration.edges.Count;
        for (int i = 0; i < length; i++)
        {
            if(string.Equals(NodeGeneration.edges[i].edgeName, currentEdge.edgeName)
                || string.Equals(NodeGeneration.edges[i].edgeName, ReverseString(currentEdge.edgeName))
                )
            {
                Destroy(gameObject);
                return;
            }
        }
        NodeGeneration.edges.Add(currentEdge);
    }

    private string ReverseString(string edgeName)
    {
        char[] charArray = edgeName.ToCharArray();
        Array.Reverse(charArray);
        edgeName = new string(charArray);
        return edgeName;
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
}
