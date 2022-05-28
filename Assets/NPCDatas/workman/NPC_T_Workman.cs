using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_T_Workman : NPC_Technologies
{
    public List<int> thresholds;
    public WorkmanManager WM;

    private void Start()
    {
        TalkBalloon = gameObject.GetComponentInChildren<TalkUI>();
        WM = gameObject.GetComponent<WorkmanManager>();
        TalkBalloon.isTalking = false;
        quested = false;
    }

    override public void Evented(int seed)
    {
        
        if (!TalkBalloon.isTalking)
        {
            progress = 0;
            TalkBalloon.openBalloon();
        }
        else
        {
            progress++;
        }

        if (WM.gameOverFlag)
        {
            //돈이 있으면, 한 번이라도 말을 걸었으면
            if (quested && CharacterManager.data._money >= thresholds[WM.timeLapse.dayNumber / 7])
            {
                if (progress == 0)
                    CharacterMove.data.Purchase();
                if (progress >= serif.ResultSerifs.Count)
                {
                    //완료
                    CharacterMove.data.PurchaseEnd();
                    WM.takeMoney(thresholds[WM.timeLapse.dayNumber / 7]);
                    TalkBalloon.closeBalloon();
                    return;
                }
                TalkBalloon.serif.text = serif.ResultSerifs[progress];

            }
            else
            {
                if (progress >= serif.QuestSerifs.Count)
                {
                    quested = true;
                    TalkBalloon.closeBalloon();
                    return;
                }

                TalkBalloon.serif.text = serif.QuestSerifs[progress];
            }
        }
        else
        {
            if (progress >= serif.RandomSerifs.Count)
            {
                progress = 0;
                TalkBalloon.closeBalloon();
                serif.rand();
                return;
            }

            TalkBalloon.serif.text = serif.RandomSerifs[progress];
        }
    }
}
