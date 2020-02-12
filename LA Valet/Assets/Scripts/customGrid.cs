using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customGrid : MonoBehaviour
{

    public GameObject target;
    public GameObject structure;
    public float gridSize;
    private Collider collider;
    Vector3 truePos;
     
    void LateUpdate()
    {
        truePos.x = Mathf.Round(target.transform.position.x / gridSize) * gridSize;
     //   truePos.y = Mathf.Round(target.transform.position.y / gridSize) * gridSize;
        truePos.z = Mathf.Round(target.transform.position.z / gridSize) * gridSize;
        
        if (structure.transform.position.z != truePos.z && Mathf.Round(structure.transform.rotation.y) == 0 )
        {
            

            structure.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self); 

        }
        if (structure.transform.position.x != truePos.x && Mathf.Round(structure.transform.rotation.y) != 0)
        {
            Debug.Log("hereeeeeee "+ structure.transform.rotation.y);
           
            //  && Mathf.Round(structure.transform.rotation.y) == 90.0f;
          /*  Debug.Log("OriginalPos: " + structure.transform.position.x + " " + structure.transform.position.z);
            Debug.Log("truePos: " + truePos.x + " " + truePos.z); */
            structure.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);

        }
        collider = structure.GetComponent<Collider>();
        //Debug.Log(collider.isTrigger);
        structure.transform.position = truePos;
    }
}
