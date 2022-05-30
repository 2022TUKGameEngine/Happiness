using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC_Technologies : MonoBehaviour
{
    public UnityEvent TakeFunctions;

    public TMPro.TMP_Text NName;
    public NPC_Serifs serif;

    protected TalkUI TalkBalloon;

    [System.NonSerialized]
    public int progress;
    public bool quested = false;

    private void Start() {
        TalkBalloon = gameObject.GetComponentInChildren<TalkUI>();
    }

    virtual public void Evented(int seed)
    {
        //NEED for Serif System
        if (!TalkBalloon.isTalking)
        {
            progress = 0;
            TalkBalloon.openBalloon();
        }
        else
        {
            progress++;
        }

        if (progress >= serif.RandomSerifs.Count)
        {
            progress = 0;
            TalkBalloon.closeBalloon();
            serif.rand();
            return;
        }

        TalkBalloon.serif.text = serif.RandomSerifs[progress];
        //*************************
    }
    
}
