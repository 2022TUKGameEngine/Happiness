using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    void Update()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.active)
            {
                return;
            }
        }

        foreach (Transform child in transform)
        {
            print("active component");
            child.gameObject.GetComponent<MiningEvent>().InitScale();
        }
    }
}
