using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TimeLapse TimeManager;
    private int nowHour = 0;
    private int nowMinute = 0;
    public CharacterManager player;
    public TMP_Text time;

    
    // Start is called before the first frame update
    void Start()
    {
        nowHour = TimeManager.Hour;
        nowMinute = TimeManager.Minute-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Minute != nowMinute)
        {
            nowMinute = TimeManager.Minute;
            time.text = TimeManager.getTimeContext();
        }
        if (TimeManager.Hour != nowHour)
        {
            if (TimeManager.isDay)
            {
                player.PlayerHP+=1;
            }
            else
            {
                player.PlayerHP+=2;
            }
            
        }
    }
}
