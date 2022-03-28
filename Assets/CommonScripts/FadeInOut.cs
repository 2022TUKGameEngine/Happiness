using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private bool isFade = false;

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
