using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class TimeLapse : MonoBehaviour
{
    public GameObject dirLight;
    public float TimeForOneDayByMinutes;
    
    Vector3 angleFactor;

    public int Hour;
    public int Minute;

    public bool isDay;
    public int CountDay;
    public float AngleX;


    // Start is called before the first frame update
    void Start()
    {
        angleFactor = new Vector3(0, -90, 0);
        isDay=true;
        CountDay=1;
    }

    // Update is called once per frame
    void Update()
    {
        AngleX=angleFactor.x;

        //360.f / (angleFactor.x % 360) = (-25%)
        angleFactor.x += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        //angleFactor.y += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        
        dirLight.transform.localEulerAngles=angleFactor;

        if(AngleX>180f)
            isDay=false;

        if(AngleX>360f)
        {
            isDay=true;
            CountDay+=1;
            angleFactor.x=0;
        }

        Hour=(int)(AngleX/15);
        Minute=(int)(AngleX%15*4);

    }

    public string getTimeContext()
    {
        return CountDay.ToString()+" days, "+Hour.ToString()+":"+Minute.ToString();
    }
}
