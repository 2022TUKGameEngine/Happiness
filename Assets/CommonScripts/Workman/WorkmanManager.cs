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
            //���� ����
        }

        isDayOfCatcher();
        if (gameOverFlag)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    public void isDayOfCatcher()    //��¥ �ٲ�� ó����
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
