using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//LEGACY
public class SleepEvent : EventComponent
{
    public DayNightCycle timeLapse;


    public override void TriggerEvent()
    {
        timeLapse.addTime(360);
        
        CharacterStatus.ChangeStress(-100);
    }

}
