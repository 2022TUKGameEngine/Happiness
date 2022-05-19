using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public DayNightCycle TimeManager;
    private int nowHour = 0;
    private int nowMinute = 0;
    public CharacterManager player;
    public TMP_Text time;

    
    // Start is called before the first frame update
    void Start()
    {
        nowHour = TimeManager.hours;
        nowMinute = TimeManager.minutes-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.minutes != nowMinute)
        {
            nowMinute = TimeManager.minutes;
            time.text = TimeManager.getTimeContext();
        }
        if (TimeManager.hours != nowHour)
        {
            nowHour = TimeManager.hours;
            if (TimeManager.DayCycle==DayNightCycle.Cycle.Night)
            {
                player.ChangeStress(2);
            }
            else
            {
                player.ChangeStress(1);
            }
            
        }
    }
}
