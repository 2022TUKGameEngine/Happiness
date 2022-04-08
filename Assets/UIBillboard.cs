using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    public Camera c;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(c.transform);
    }
}
