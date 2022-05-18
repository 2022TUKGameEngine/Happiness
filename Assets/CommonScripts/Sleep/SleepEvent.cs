using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SleepEvent : EventComponent

{
    public TimeLapse timeLapse;
    UnityEvent m_Events=new UnityEvent();

    void Awake()
    {
        m_Events.AddListener(DayLeft);
    }

    public override void TriggerEvent()
    {
        if(timeLapse.angleFactor.x>=270f || timeLapse.angleFactor.x<0f)
        {
            timeLapse.angleFactor.x=90f;
            timeLapse.CountDay+=1;
            m_Events.Invoke();
            CharacterStatus.EarnHP(100);
            if(timeLapse.Hour>6)
            {
                CharacterStatus.LoseHP(10*(timeLapse.Hour-6));
            }
        }
        else
        {
            timeLapse.angleFactor.x=270f;
            FarmingSystem.instance.dayUpdate();

            CharacterStatus.EarnHP(100);
            if(timeLapse.Hour>18)
            {
                CharacterStatus.LoseHP(10*(timeLapse.Hour-18));
            }
        }
    }

    void DayLeft()
    {
        Debug.Log("1 Day Left");
    }
}
