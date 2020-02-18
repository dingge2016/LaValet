using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteSceneSwitch : MonoBehaviour
{
    public void gameSwitcher()
    {
        SceneManager.LoadScene(0);
    }
}
