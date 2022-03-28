using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    private bool isFade = false;
    private Image fadeImage;

    private void Awake() 
    {
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
    }

    void OnTriggerStay(Collider coll)
    {
        if(IsFadeStart(ref coll))
        {
            isFade = true;
        }
    }

    bool IsFadeStart(ref Collider coll)
    {
        if (!coll.CompareTag("Player")) {return false;}
        if (!Input.GetKeyUp(KeyCode.Q)) {return false;}
    
        return true;
    }
}
