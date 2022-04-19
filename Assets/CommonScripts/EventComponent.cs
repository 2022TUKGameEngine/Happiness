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
    public GameObject Shop;
    public InventorySystem Inventory;
    
    public GameObject chairObject;
    private bool _isFishing = false;
    private float _waitingTime = 0.0f;
    private float _fishTimer = 0.0f;

    public float minFish = 3.0f;
    public float maxFish = 7.0f;

    public int FishLevel;
    
    public void TriggerEvent()
    {
        Debug.Log(EventType);
        switch(EventType)
        {
        case "Sleep":
            if(timeLapse.angleFactor.x>=270f || timeLapse.angleFactor.x<0f)
            {
                timeLapse.angleFactor.x=90f;
                timeLapse.CountDay+=1;
                CharacterStatus.EarnHP(100);
                if(timeLapse.Hour>6)
                {
                    CharacterStatus.LoseHP(10*(timeLapse.Hour-6));
                }
            }
            else
            {
                timeLapse.angleFactor.x=270f;
                FarmingSystem.instance.dayUpdate();

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
            chairObject.SetActive(_isFishing);

            if (_isFishing == false)
            {
                return;
            }
            
            InitFishTimer();
            break; 

        case "Farming":

            int groundNum = (int)gameObject.GetComponent<floatsDataContainer>()._float1;

            if (FarmingSystem.instance.isGroundFarmed(groundNum) > 0)
            {
                FarmingSystem.instance.watering(groundNum);
            }
            else if (FarmingSystem.instance.isGroundFarmed(groundNum) == 0)
            {
                if (CharacterManager.data.inventory.GetComponent<InventorySystem>().useItem(ITEM_TYPE.Seed))
                {
                    FarmingSystem.instance.plantSeed(gameObject, groundNum);
                }
            }
            else
            {
                FarmingSystem.instance.clearGround(groundNum);
            }

            break;
        
        case "Shopping":

            Shop.SetActive(true);

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

    public void BuyItem()
    {
        InventorySystem.instance.GetItem(ITEM_TYPE.Fish,FishLevel);
    }
    
}
