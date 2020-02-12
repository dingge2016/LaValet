using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchExit : MonoBehaviour
{

      

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("A car"))
        {
           other.gameObject.SetActive(false);
        }
    }
}
