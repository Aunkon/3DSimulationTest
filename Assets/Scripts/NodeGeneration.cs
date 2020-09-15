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

    public void GenerateNodes(int nodesLength)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            Destroy(nodes[i]);
        }
        for (int i = 0; i < edges.Count; i++)
        {
            Destroy(edges[i]);
        }
        GenerateCircle(nodesLength);
    }

    private void GenerateCircle(int nodesLength)
    {
        float radius = 4.5f;
        for (int i = 0; i < nodesLength; i++)
        {
            float angle = i * Mathf.PI * 2f / nodesLength;
            Vector3 newPosition = new Vector3(Mathf.Cos(angle) * radius, 0.25f, Mathf.Sin(angle) * radius);
            AddNode(newPosition);
        }
    }

    public void AddNode(Vector3 newPosition)
    {
        GameObject newNode = Instantiate(node, transform);        
        GameObject newEdge = Instantiate(edge, transform);

        nodes.Add(newNode);
        edges.Add(newEdge);

        newNode.transform.position = newPosition; // Move node position to scaled Edges by Edge.cs

        newEdge.GetComponent<Edge>().StartNode = rootNote;
        newEdge.GetComponent<Edge>().EndNode = newNode.GetComponent<Node>();
    }
}