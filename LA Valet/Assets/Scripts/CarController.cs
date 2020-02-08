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
             transform.position = new Vector3(lastPos.x, lastPos.y, lastPos.z);
         }
         
         /*
         
         private Vector3 screenPoint;

         void OnMouseDown(){
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
         }

         void OnMouseDrag(){
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            transform.position = currentPos;
         }
         */
         

}
