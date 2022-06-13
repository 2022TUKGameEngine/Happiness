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

        gameOverFlag = isDayOfCatcher();
        gameObject.SetActive(gameOverFlag);
    }

    public bool isDayOfCatcher()
    {
        return (timeLapse.dayNumber % 7 == 0 && timeLapse.dayNumber > 0);
    }

    public void takeMoney(int amount)
    {
        CharacterManager.data.EarnMoney(-1 * amount);
        gameOverFlag = false;
    }
}
