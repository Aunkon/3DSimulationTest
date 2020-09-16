﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGeneration : MonoBehaviour
{
    public GameObject node;

    public static List<GameObject> nodes;

    void Start()
    {
        nodes = new List<GameObject>();
    }

    //Destroy Previous Nodes and Generate New nodes from API data
    public void GenerateNodes(int nodesLength)
    {
        DestroyNodesNEdges();
        //GenerateCircle(nodesLength);
        GenerateBox(nodesLength);
    }

    private void DestroyNodesNEdges()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            Destroy(nodes[i]);
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

    private void GenerateBox(int nodesLength)
    {
        float distance = 9f / nodesLength, startPosX = -4f;

        for (int i = 0; i < nodesLength; i++)
        {
            Vector3 newPosition = new Vector3(startPosX, 0.35f, 0f);
            AddNode(newPosition);
            startPosX += distance;
        }
    }

    //Spawn Node and Edges
    private void AddNode(Vector3 newPosition)
    {
        GameObject newNode = Instantiate(node, transform); //Node Spawn
        //GameObject newEdge = Instantiate(edge, transform); //Edge Spawn

        //Material Color Randomization
        newNode.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //Add node to a list for future destroy
        nodes.Add(newNode);
        //edges.Add(newEdge);

        // Move node position to scaled Edges by Edge.cs
        newNode.transform.position = newPosition;

        //Connect new node with root node
        //newEdge.GetComponent<Edge>().startNode = rootNote;
        //newEdge.GetComponent<Edge>().endNode = newNode.GetComponent<Node>();
    }

    public void ConnectorGeneration(bool isActivate)
    {
        if (isActivate)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].GetComponent<NodeDrag>().canDrag = false;
                nodes[i].GetComponent<ConnectorGenerator>().canConnect = true;
            }
        }
        else
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].GetComponent<NodeDrag>().canDrag = true;
                nodes[i].GetComponent<ConnectorGenerator>().canConnect = false;
            }
        }
    }
}