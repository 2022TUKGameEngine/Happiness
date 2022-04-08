using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PuffEvent : MonoBehaviour
{
    public VisualEffect[] LvisualEffect;
    public Transform LeftToe;
    public VisualEffect[] RvisualEffect;
    public Transform RightToe;

    int lBuffer = 0;
    int rBuffer = 0;
    void Lpuff()
    {
        LvisualEffect[lBuffer].transform.position = new Vector3(LeftToe.position.x, LeftToe.position.y, LeftToe.position.z);
        LvisualEffect[lBuffer].Play();
        lBuffer ^= 1;
    }
    void Rpuff()
    {
        RvisualEffect[rBuffer].transform.position = new Vector3(RightToe.position.x, RightToe.position.y, RightToe.position.z);
        RvisualEffect[rBuffer].Play();
        rBuffer ^= 1;
    }
}
