using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkmanManager : MonoBehaviour
{
    public TimeLapse timeLapse;

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
            //게임 오버
        }

        isDayOfCatcher();
        if (gameOverFlag)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    public void isDayOfCatcher()    //날짜 바뀌면 처리함
    {
        if (timeLapse.CountDay % 7 == 0)
        {
            gameOverFlag = true;
        }
        else
        {
            gameOverFlag = false;
        }
    }

    public void takeMoney()
    {
        gameOverFlag = false;
    }
}
