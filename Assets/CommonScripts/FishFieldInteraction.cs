using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFieldInteraction : MonoBehaviour
{
    public Collider _fishCollider;

    private void Awake() 
    {
        _fishCollider.enabled = false;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishCollider"))
        {
            _fishCollider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishCollider"))
        {
            _fishCollider.enabled = false;
        }
    }
}
