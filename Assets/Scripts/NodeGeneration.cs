using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGeneration : MonoBehaviour
{
    public GameObject node;
    public GameObject edge;

    public Node rootNote;

    private List<GameObject> nodes;
    private List<GameObject> edges;

    void Start()
    {
        nodes = new List<GameObject>();
        edges = new List<GameObject>();
    }

    //Destroy Previous Nodes and Generate New nodes from API data
    public void GenerateNodes(int nodesLength)
    {
        DestroyNodesNEdges();
        GenerateCircle(nodesLength);
    }

    private void DestroyNodesNEdges()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            Destroy(nodes[i]);
        }
        for (int i = 0; i < edges.Count; i++)
        {
            Destroy(edges[i]);
        }
    }

    //Calculated a circle vector 3 position arround vector3.zero
    private void GenerateCircle(int nodesLength)
    {
        float radius = 4.5f;
        for (int i = 0; i < nodesLength; i++)
        {
            float angle = i * Mathf.PI * 2f / nodesLength;
            Vector3 newPosition = new Vector3(Mathf.Cos(angle) * radius, 0.35f, Mathf.Sin(angle) * radius);
            AddNode(newPosition);
        }
    }

    //Spawn Node and Edges
    private void AddNode(Vector3 newPosition)
    {
        GameObject newNode = Instantiate(node, transform); //Node Spawn
        GameObject newEdge = Instantiate(edge, transform); //Edge Spawn

        //Material Color Randomization
        newNode.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //Add node to a list for future destroy
        nodes.Add(newNode);
        edges.Add(newEdge);

        // Move node position to scaled Edges by Edge.cs
        newNode.transform.position = newPosition;

        //Connect new node with root node
        newEdge.GetComponent<Edge>().startNode = rootNote;
        newEdge.GetComponent<Edge>().endNode = newNode.GetComponent<Node>();
    }
}