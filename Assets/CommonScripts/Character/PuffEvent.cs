using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PuffEvent : MonoBehaviour
{
    public VisualEffect LvisualEffect;
    public Transform LeftToe;
    public VisualEffect RvisualEffect;
    public Transform RightToe;
    void Lpuff()
    {
        LvisualEffect.transform.position = new Vector3(LeftToe.position.x, LeftToe.position.y, LeftToe.position.z);
        LvisualEffect.Play();
    }
    void Rpuff()
    {
        RvisualEffect.transform.position = new Vector3(RightToe.position.x, RightToe.position.y, RightToe.position.z);
        RvisualEffect.Play();
    }
}
