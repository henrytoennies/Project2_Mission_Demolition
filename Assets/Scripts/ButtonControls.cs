using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour
{
    void Start()
    {
        
    }

    public void ToMainGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
