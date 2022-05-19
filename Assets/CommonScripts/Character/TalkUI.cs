using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkUI : MonoBehaviour
{
    private Animator anim;
    public bool isTalking;
    public TMPro.TMP_Text serif;

    void Start()
    {
        isTalking = false;
        anim = GetComponent<Animator>();
    }

    public void openBalloon()
    {
        if (!isTalking)
        {
            isTalking = true;
            anim.SetTrigger("OpenInventory");
        }
    }
    public void closeBalloon()
    {
        if (isTalking)
        {
            isTalking = false;
            anim.SetTrigger("CloseInventory");
        }
    }
}
