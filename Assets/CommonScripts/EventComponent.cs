using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
    public TimeLapse timeLapse;
    public GameManager GameStatus;
    
    private bool _isFishing = false;
    private float _waitingTime = 0.0f;
    private float _fishTimer = 0.0f;

    public float minFish = 3.0f;
    public float maxFish = 7.0f;

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

            InitFishTimer();
            break; 
        }
    }

    private void Update() 
    {
        if (_isFishing)
        {
            doFishing();
        }    
    }

    private void InitFishTimer()
    {
        _waitingTime = Random.Range(minFish, maxFish);
        _fishTimer = 0.0f;
    }

    private void doFishing()
    {
        _fishTimer += Time.deltaTime;
        if (_fishTimer > _waitingTime)
        {
            inventory.GetItem(ITEM_TYPE.Fish, 1);
            InitFishTimer();
        }
    }
}
