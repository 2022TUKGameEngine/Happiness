using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkmanManager : MonoBehaviour
{
    public DayNightCycle timeLapse;

    public bool gameOverFlag;

    public void Start()
    {
        gameOverFlag = false;
        dayChanged();
    }

    public void dayChanged()
    {
        if (gameOverFlag)
        {
            GameOverManager.Instance.setGameOver();
        }

        isDayOfCatcher();
        if (gameOverFlag)
        {
            gameObject.SetActive(true);
        }
        else
        {
            
            gameObject.SetActive(false);
        }
    }

    public void isDayOfCatcher()    //��¥ �ٲ�� ó����
    {
        if (timeLapse.dayNumber % 7 == 0 && timeLapse.dayNumber > 0)
        {
            gameOverFlag = true;
        }
        else
        {
            gameOverFlag = false;
        }
    }

    public void takeMoney(int amount)
    {
        CharacterManager.data.EarnMoney(-1 * amount);
        gameOverFlag = false;
    }
}
