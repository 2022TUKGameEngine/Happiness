using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
    public TimeLapse timeLapse;
    public GameManager GameStatus;
    private bool _isFishing = false;
    [SerializeField]
    private InventorySystem inventory;

    public void TriggerEvent()
    {
        Debug.Log(EventType);
        switch(EventType)
        {
        case "Sleep":
            if(timeLapse.AngleX<180f && timeLapse.AngleX>0f)
            {
                timeLapse.AngleX=180f;
            }
            else
            {
                timeLapse.AngleX=0f;
                timeLapse.CountDay+=1;

            }

            break;

        case "Fishing":
            _isFishing = !_isFishing;
            
            if (_isFishing == false)
            {
                return;
            }
            break; 
        }
    }

    private void Update() 
    {
        if (_isFishing)
        {
        }    
    }

    }
}
