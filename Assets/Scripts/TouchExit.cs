using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchExit : MonoBehaviour
{



    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag("A car"))
        {
            Debug.Log("car");
            other.gameObject.SetActive(false); 
        } else if (other.gameObject.CompareTag("Control Bar"))
        {
            Debug.Log("bar");
            other.gameObject.SetActive(false);
        }
    }
}