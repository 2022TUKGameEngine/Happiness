using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayNightCycle : MonoBehaviour
{
    [Header("Time")]
    [Tooltip("Day Length In Minutes")]
    [SerializeField]

    private float _targetDayLength=0.5f;    //  30초마다 하루 지나감, 1이면 1분에 하루
    public float targetDayLength
    {
        get
        {
            return _targetDayLength;
        }
    }
    [SerializeField]
    [Range(0f,1f)]
    private float _timeOfDay;
    [SerializeField]
    private int _minutes;
    public int minutes
    {
        get
        {
            return _minutes;
        }
    }
    [SerializeField]
    private int _hours;
    public int hours
    {
        get
        {
            return _hours;
        }
    }

    [SerializeField]
    private int _dayNumber=0;               // 날짜 카운트
    public int dayNumber
    {
        get
        {
            return _dayNumber;
        }
    }
    [SerializeField]
    private int _yearNumber=0;
    public int yearNumber
    {
        get
        {
            return _yearNumber;
        }
    }
    private float _timeScale=100f;
    [SerializeField]
    public bool pause=false;

    [Header("Sun Light")]
    [SerializeField]
    private Transform dailyRotation;
    [SerializeField]
    private Light sun;
    private float intensity;
    [SerializeField]
    private float sunBaseIntensity=1f;      //최소 밝기
    private float sunVariation=1.5f;        //밝기 변화
    [SerializeField]
    private Gradient sunColor;

    public UnityEvent daybreakEvents;

    public  enum Cycle
    {
        Morning,
        Afternoon,
        Evening,
        Night
    };

    public Cycle DayCycle;

    private void Awake()
    {
        DayCycle=Cycle.Morning;
    }

    private void Update()
    {
        if(!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }
        adjustSunRotation();
    }

    private void UpdateTimeScale()
    {
        _timeScale=24/(_targetDayLength/60);
    }

    private void UpdateTime()
    {
        _timeOfDay+=Time.deltaTime*_timeScale/86400;    //86400는 하루를 초로 계산한 값
        _minutes=((int)(_timeOfDay*86400)%3600)/60;
        _hours=((int)(_timeOfDay*86400)/3600)+6;
        if(_hours>=24)
        {
            _hours-=24;
        }
        if(_timeOfDay>1)
        {
            _dayNumber++;
            _timeOfDay-=1;

            daybreakEvents.Invoke();

        }

        // if(_hours>=6&&_hours<12)
        // {
        //     DayCycle=Cycle.Morning;
        //     SoundManager.instance.SwapBGM();

        // }
        // else if(_hours>=12&&_hours<18)
        // {
        //     DayCycle=Cycle.Afternoon;
        // }

        // else if(_hours>=18&&_hours<24)
        // {
        //     DayCycle=Cycle.Evening;
        //     SoundManager.instance.SwapBGM();
        // }
        // else
        // {
        //     DayCycle=Cycle.Night;
        // }


    }

    //태양 각도 회전
    private void adjustSunRotation()
    {
        float sunAngle=_timeOfDay*360f;
        dailyRotation.transform.localRotation=Quaternion.Euler(new Vector3(0f,0f,sunAngle));
    }

    private void SunIntensity()
    {
        intensity=Vector3.Dot(sun.transform.forward,Vector3.down);
        intensity=Mathf.Clamp01(intensity);

        sun.intensity=intensity*sunVariation+sunBaseIntensity;
    }
    
    private void adjustSunColor()
    {
        sun.color=sunColor.Evaluate(intensity);
    }

    public string getTimeContext()
    {
        return "Day "+dayNumber.ToString()+"  "+hours.ToString()+":"+minutes.ToString();
    }

    public void addTime(float addMinutes)
    {
        _timeOfDay+=addMinutes/1440f;
    }
}
