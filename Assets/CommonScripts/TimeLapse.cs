using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class TimeLapse : MonoBehaviour
{
    public GameObject dirLight;
    public float TimeForOneDayByMinutes;
    
    public Vector3 angleFactor;

    public int Hour;
    public int Minute;

    public  enum Cycle
    {
        Morning,
        Afternoon,
        Evening,
        Night
    };

    public Cycle DayCycle;

    public int CountDay;


    // Start is called before the first frame update
    void Start()
    {
        angleFactor = new Vector3(0, -90, 0);
        DayCycle=Cycle.Morning;
        CountDay=1;
    }

    // Update is called once per frame
    void Update()
    {

        //360.f / (angleFactor.x % 360) = (-25%)
        angleFactor.x += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        //angleFactor.y += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        
        dirLight.transform.localEulerAngles=angleFactor;

        if(angleFactor.x>=0f && angleFactor.x<90f)
        {
            DayCycle=Cycle.Morning;
        }

        else if(angleFactor.x>=90f && angleFactor.x<180f)
        {
            DayCycle=Cycle.Afternoon;
        }
        else if(angleFactor.x>=180f && angleFactor.x<270f)
        {
            DayCycle=Cycle.Evening;
        }
        else if(angleFactor.x>=270f&&angleFactor.x<360f)
        {
            DayCycle=Cycle.Night;
        }

        if(angleFactor.x>360f)
        {
            CountDay+=1;
            angleFactor.x=0;
            FarmingSystem.instance.dayUpdate();
        }

        Hour=(int)(angleFactor.x/15);
        Minute=(int)(angleFactor.x%15*4);

    }

    public string getTimeContext()
    {
        return CountDay.ToString()+" days, "+Hour.ToString()+":"+Minute.ToString();
    }

    public int getHour()
    {
        return Hour;
    }
}
