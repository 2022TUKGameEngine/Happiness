using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour
{
    public static DebugMode instance;
    public GameObject debugText;
    public bool debugMode;
    public GameObject player;

    void Awake()
    {
        if (debugMode)
            PlayerPrefs.DeleteAll();
        instance = this;
    }
    
    void Start()
    {
        
        debugText.SetActive(false);

    }
}
