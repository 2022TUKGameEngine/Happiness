using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC_Technologies : MonoBehaviour
{
    public UnityEvent TakeFunctions;

    public NPC_Serifs serif;

    protected TalkUI TalkBalloon;

    public int progress;
    public bool quested = false;

    private void Start() {
        TalkBalloon = gameObject.GetComponentInChildren<TalkUI>();
    }

    virtual public void Evented(int seed)
    {

    }
    
}
