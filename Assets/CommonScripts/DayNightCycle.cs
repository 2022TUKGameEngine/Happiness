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
    public UnityEvent morningEvents;
    bool morningTicker = true;

    public  enum Cycle
    {
        Morning,
        Afternoon,
        Evening,
        Night
    };

    public Cycle DayCycle;
    private Color32 LerpedColor;
    private Color32 NightColor=new Color32(35,45,115,255);
    private Color32 DayColor=new Color32(255,243,221,255);
    private void Awake()
    {
        DayCycle=Cycle.Morning;
    }

    public Material m_Material;
    public Material m_Material_1;

    private void Update()
    {
        if(!pause)
        {
            UpdateTimeScale();
            UpdateTime();

            if(_timeOfDay>=0.5&&_timeOfDay<1)
                RenderSettings.ambientLight=new Color32(35,45,115,255);
            else //if(_timeOfDay>=0&&_timeOfDay<0.25)
                {
                    //RenderSettings.ambientLight=DayColor;
                    LerpedColor=Color32.Lerp(NightColor,DayColor,Mathf.PingPong(_timeOfDay,0.25f));
                    RenderSettings.ambientLight=new Color32(LerpedColor.r,LerpedColor.g,LerpedColor.b,LerpedColor.a);
                }
            // else if(_timeOfDay>=0.25&&_timeOfDay<0.5)
            // {
            //         LerpedColor=Color32.Lerp(DayColor,NightColor,Mathf.PingPong(_timeOfDay,0.5f));
            //         RenderSettings.ambientLight=new Color32(LerpedColor.r,LerpedColor.g,LerpedColor.b,LerpedColor.a);
            // }
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
            morningTicker = true;

            daybreakEvents.Invoke();
        }
        if(_hours>=19 || _hours <= 5)
        {
            if (morningTicker)
            {
                morningEvents.Invoke();
                morningTicker = false;
            }
            m_Material.SetFloat("_EmissionPower", 10.0f);
            m_Material_1.SetFloat("_EmissionPower", 3.0f);
        }
        else
        {
            m_Material.SetFloat("_EmissionPower", 0.0f);
            m_Material_1.SetFloat("_EmissionPower", 0.5f);
        }
        


        // if(_hours>=6&&_hours<12)
        // {
        //     DayCycle=Cycle.Morning;
        //     //SoundManager.instance.SwapBGM();

        // }
        // else if(_hours>=12&&_hours<18)
        // {
        //     DayCycle=Cycle.Afternoon;
        // }

        // else if(_hours>=18&&_hours<24)
        // {
        //     DayCycle=Cycle.Evening;
        //     //SoundManager.instance.SwapBGM();
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
