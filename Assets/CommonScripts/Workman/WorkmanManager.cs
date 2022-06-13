using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkmanManager : MonoBehaviour
{
    public DayNightCycle timeLapse;

    public bool gameOverFlag;
    private bool isGameClearWeek;

    public void Start()
    {
        gameOverFlag = false;
        isGameClearWeek = false;
        dayChanged();
    }

    public void dayChanged()
    {
        CheckGameEnd();
        
        isGameClearWeek = gameOverFlag = isDayOfCatcher();
        isGameClearWeek = (isGameClearWeek && timeLapse.dayNumber >=14) ? true : false;
        gameObject.SetActive(gameOverFlag);
    }

    public void CheckGameEnd()
    {
        if(isGameClearWeek && !gameOverFlag){
            GameOverManager.Instance.setGameClear();
        }

        if (gameOverFlag){
            GameOverManager.Instance.setGameOver();
        }
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
