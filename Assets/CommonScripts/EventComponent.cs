using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
    public TimeLapse timeLapse;
    public GameManager GameStatus;
    public Animator animController;
    public CharacterManager CharacterStatus;
    
    private bool _isFishing = false;
    private float _waitingTime = 0.0f;
    private float _fishTimer = 0.0f;

    public float minFish = 3.0f;
    public float maxFish = 7.0f;
    
    public void TriggerEvent()
    {
        Debug.Log(EventType);
        switch(EventType)
        {
        case "Sleep":
            if(timeLapse.angleFactor.x>=0f && timeLapse.angleFactor.x<180f)
            {
                timeLapse.angleFactor.x=180f;
                CharacterStatus.EarnHP(100);
                if(timeLapse.Hour>6)
                {
                    CharacterStatus.LoseHP(10*(timeLapse.Hour-6));
                }
            }
            else
            {
                timeLapse.angleFactor.x=0f;
                timeLapse.CountDay+=1;

                CharacterStatus.EarnHP(100);
                if(timeLapse.Hour>18)
                {
                    CharacterStatus.LoseHP(10*(timeLapse.Hour-18));
                }

            }

            break;

        case "Fishing":

            _isFishing = !_isFishing;
            animController.SetBool("isSitting", _isFishing);

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
            InventorySystem.instance.GetItem(ITEM_TYPE.Fish, 1);
            InitFishTimer();
        }
    }
}
