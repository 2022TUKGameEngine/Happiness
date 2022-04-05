using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour
{

    public GameObject debugText;
    public bool debugMode;
    public GameObject player;

    void Start()
    {
        if (debugMode)
            debugText.SetActive(true);
        else
            debugText.SetActive(false);

    }

    void Update()
    {
        if (debugMode)
        {
            // if (Input.GetKeyDown(KeyCode.PageUp))
            // {
            //     player.GetComponent<CharacterMove>().moveSpeed += 0.05f;
            // }
            // if (Input.GetKeyDown(KeyCode.PageDown))
            // {
            //     player.GetComponent<CharacterMove>().moveSpeed -= 0.05f;
            // }
            
            // //채소 심기
            // if (Input.GetKeyDown(KeyCode.Alpha1))
            // {
                
            // }
        }
    }
}
