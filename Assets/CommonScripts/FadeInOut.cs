using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private bool isFade = false;

    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if(Input.GetKeyUp(KeyCode.Q))
            {
                isFade = true;
            }
        }
    }
}
