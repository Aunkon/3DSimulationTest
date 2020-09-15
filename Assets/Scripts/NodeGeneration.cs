using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGeneration : MonoBehaviour
{
    //Center is transform.position
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
            //GameObject go = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), newPos, Quaternion.identity);
            AddNode(newPosition);
        }
    }

    public void AddNode(Vector3 newPosition)
    {
        if(edges.Count == 0)
        {
            GameObject newNode1 = Instantiate(node, newPosition, Quaternion.identity);
            GameObject newNode2 = Instantiate(node, newPosition, Quaternion.identity);
            GameObject newEdge = Instantiate(edge, newPosition, Quaternion.identity);

            nodes.Add(newNode1);
            nodes.Add(newNode2);
            edges.Add(newEdge);

            newNode1.transform.position = Vector3.zero;
            newNode2.transform.position = Vector3.one;

            newEdge.GetComponent<Edge>().StartNode = rootNote;
            newEdge.GetComponent<Edge>().EndNode = newNode2.GetComponent<Node>();
        }
        else if(edges.Count == 1) //I have 2 nodes adding one more lets me create a polygon/triangle and a connected graph
        {
            GameObject newNode = Instantiate(node, newPosition, Quaternion.identity);
            GameObject newEdge1 = Instantiate(edge, newPosition, Quaternion.identity);
            GameObject newEdge2 = Instantiate(edge, newPosition, Quaternion.identity);

            nodes.Add(newNode);
            edges.Add(newEdge1);
            edges.Add(newEdge2);

            newNode.transform.position = Vector3.one * edges.Count;

            newEdge1.GetComponent<Edge>().StartNode = rootNote;
            newEdge1.GetComponent<Edge>().EndNode = newNode.GetComponent<Node>();

            newEdge2.GetComponent<Edge>().StartNode = rootNote;
            newEdge2.GetComponent<Edge>().EndNode = nodes[0].GetComponent<Node>();


        }
        else //If I have more than 3 nodes I can keep increasing the edge count of my graph in a circular design
        {
            GameObject newNode = Instantiate(node, newPosition, Quaternion.identity);
            GameObject newEdge = Instantiate(edge, newPosition, Quaternion.identity);

            nodes.Add(newNode);
            edges.Add(newEdge);

            newNode.transform.position = Vector3.one * edges.Count;

            edges[edges.Count - 2].GetComponent<Edge>().EndNode = newNode.GetComponent<Node>();

            newEdge.GetComponent<Edge>().StartNode = rootNote;
            newEdge.GetComponent<Edge>().EndNode = nodes[0].GetComponent<Node>();
        }
    }
}