using UnityEngine;

public class Node : MonoBehaviour
{
    //void OnMouseDrag()
    //{
    //    float WorldZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //z axis of the game object for screen view
    //    Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, WorldZCoordinate); //z axis added to screen point 
    //    Vector3 NewWorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point
    //    transform.position = NewWorldPosition;
    //}
    //void OnMouseExit() //There will be no transform change
    //{
    //    transform.hasChanged = false;
    //}

    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;
    void OnMouseDown()
    {
        startPos = transform.position;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;
    }

    void OnMouseDrag()
    {
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
        transform.position = new Vector3(lastPos.x, startPos.y, lastPos.z);
    }
}
