using UnityEngine;

public class Edge : MonoBehaviour
{
    public Node startNode;
    public Node endNode;

    void Update()
    {
        if (startNode.transform.hasChanged || endNode.transform.hasChanged)
        {
            Resize();
        }
    }

    void Resize()
    {
        float distance = Vector3.Distance(startNode.transform.position, endNode.transform.position);
        transform.localScale = new Vector3(0.25f, 0.25f, distance);

        Vector3 middlePoint = (startNode.transform.position + endNode.transform.position) / 2;
        transform.position = middlePoint;

        Vector3 rotationDirection = (endNode.transform.position - startNode.transform.position);
        transform.rotation = Quaternion.LookRotation(rotationDirection);
    }
}
