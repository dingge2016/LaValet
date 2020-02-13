using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCollision : MonoBehaviour
{
    static float zero = 0;
    static float posInf = 1/zero;
    static float negInf = -1/zero;

    public static float minX = negInf;
    public static float minZ = negInf;
    public static float maxX = posInf;
    public static float maxZ = posInf;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
      var tag = collision.collider.tag;
      if (tag == "Wall"){
        // Get a Connect Point
        ContactPoint contact = collision.GetContact(0);
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Collider otherCollider = contact.otherCollider; // collider1: The object that is collided
        Collider thisCollider = contact.thisCollider; // collider2: The object that collide collider1
        /*
        contact.normal
        1,0,0 => To Left
        -1,0,0 => To Right
        0,0,1 => To Down
        0,0,-1 => To Up
        */
        if (contact.normal[0] > 0){
          minX = thisCollider.transform.position[0];
        }
        if (contact.normal[0] < 0){
          maxX = thisCollider.transform.position[0];
        }
        if (contact.normal[2] > 0){
          minZ = thisCollider.transform.position[2];
        }
        if (contact.normal[2] < 0){
          maxZ = thisCollider.transform.position[2];
        }
        // Debug.Log(minX);
        // Debug.Log(maxX);
        // Debug.Log(minZ);
        // Debug.Log(maxZ);
        //Debug.Log(thisCollider.transform.position[2]);
      }
    }

    void OnCollisionExit(Collision collision)
    {

    }

    void OnCollisionStay(Collision collision)
    {

    }
}
