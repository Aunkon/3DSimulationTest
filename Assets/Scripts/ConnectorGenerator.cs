using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorGenerator : MonoBehaviour
{
    public GameObject edge;
    public bool canConnect = false;
    public static bool canSpawnConnector = true;

    private void OnMouseDown()
    {
        if (!canConnect)
        {
            return;
        }
        if (!canSpawnConnector)
        {
            return;
        }
        
        GameObject newEdge = Instantiate(edge, transform.parent); //Edge Spawn
        Edge tempEdge = newEdge.GetComponent<Edge>();
        tempEdge.startNode = this.gameObject;
        tempEdge.isActive = false;
        JointConnection tempConnection = newEdge.GetComponent<JointConnection>();
        tempConnection.startNode = transform.gameObject;
        tempConnection.isActive = true;
        canSpawnConnector = false;
    }
}
