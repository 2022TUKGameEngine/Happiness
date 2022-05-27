using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    void Update()
    {
        foreach(Transform child in transform)
        {
            Debug.Log(child.name);
        }
    }
}
