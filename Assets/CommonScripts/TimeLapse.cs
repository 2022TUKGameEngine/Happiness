using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLapse : MonoBehaviour
{
    public GameObject dirLight;
    public float TimeForOneDayByMinutes;
    Vector3 angleFactor;
    public bool DayOrNight;
    public float CountDay;

    public float AngleX;


    // Start is called before the first frame update
    void Start()
    {
        angleFactor = new Vector3(0, 0, 0);
        DayOrNight = true;
        CountDay = 1;
    }

    // Update is called once per frame
    void Update()
    {

        AngleX=angleFactor.x;

        angleFactor.x += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        //angleFactor.y += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;

        dirLight.transform.eulerAngles = angleFactor;

        if(AngleX>180f)
            DayOrNight=false;

        if(AngleX>360f)
        {
            DayOrNight=true;
            CountDay+=1;
            angleFactor.x=0;
        }




    }
}
