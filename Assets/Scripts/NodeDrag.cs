using UnityEngine;

public class NodeDrag : MonoBehaviour
{
    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;

    public bool canDrag = true;

    void OnMouseDown()
    {
        if (!canDrag)
        {
            return;
        }
        startPos = transform.position;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;
    }

    void OnMouseDrag()
    {
        if (!canDrag)
        {
            return;
        }
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
        transform.position = new Vector3(lastPos.x, startPos.y, lastPos.z);
    }
}