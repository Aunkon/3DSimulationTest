using UnityEngine;

public class Edge : MonoBehaviour
{
    public Node StartNode;
    public Node EndNode;

    void Update()
    {
        if (StartNode.transform.hasChanged || EndNode.transform.hasChanged)
        {
            Resize();
        }
    }

    void Resize()
    {
        float distance = Vector3.Distance(StartNode.transform.position, EndNode.transform.position);
        transform.localScale = new Vector3(0.25f, 0.25f, distance);

        Vector3 middlePoint = (StartNode.transform.position + EndNode.transform.position) / 2;
        transform.position = middlePoint;

        Vector3 rotationDirection = (EndNode.transform.position - StartNode.transform.position);
        transform.rotation = Quaternion.LookRotation(rotationDirection);
    }
}
