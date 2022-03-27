using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if(Input.GetKeyUp(KeyCode.Q))
            {
                print("check");
            }
        }
    }
}
