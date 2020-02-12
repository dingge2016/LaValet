using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class CarController : MonoBehaviour
{

    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posY;
    float posZ;

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

        // Debug.Log("X:" + lastPos.x + "Y:" + lastPos.y + " Z:" + lastPos.z);
        transform.position = new Vector3(lastPos.x, 0.7f, lastPos.z);
    }

  


}