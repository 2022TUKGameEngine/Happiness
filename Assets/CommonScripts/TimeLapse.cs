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

    public bool DayOrNight;
    public float CountDay;
    public float AngleX;


    // Start is called before the first frame update
    void Start()
    {
        angleFactor = new Vector3(0, -90, 0);
        DayOrNight=true;
        CountDay=1;
    }

    // Update is called once per frame
    void Update()
    {
        AngleX=angleFactor.x;

        //360.f / (angleFactor.x % 360) = ����ð�(-25%)
        angleFactor.x += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        //angleFactor.y += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        
        dirLight.transform.localEulerAngles=angleFactor;

        if(AngleX>180f)
            DayOrNight=false;

        if(AngleX>360f)
        {
            DayOrNight=true;
            CountDay+=1;
            angleFactor.x=0;
        }

        Hour=(int)(AngleX/15);
        Minute=(int)(AngleX%15*4);



    }
}
