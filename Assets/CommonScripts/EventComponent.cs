using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
    public TimeLapse Time;
    public GameManager GameStatus;
    
    [SerializeField]
    private InventorySystem inventory;

    public void TriggerEvent()
    {
        Debug.Log(EventType);
        switch(EventType)
        {
        case "Sleep":
            if(Time.AngleX<180f && Time.AngleX>0f)
            {
                Time.AngleX=180f;
            }
            else
            {
                Time.AngleX=0f;
                Time.CountDay+=1;

            }

            break;

        case "Fishing":
            break; 
        }

    }
}
