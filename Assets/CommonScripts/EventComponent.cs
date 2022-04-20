using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
    public TimeLapse timeLapse;
    public GameManager GameStatus;
    public CharacterManager CharacterStatus;
    public GameObject Shop;
    public GameObject ShopPanel;
    public int FishLevel;
    
    public virtual void TriggerEvent()
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
            ShopPanel.GetComponent<DragAndDrop>().ResetPos();
            
            break;
        }
    }

    protected virtual void Update() 
    {

    }

    public void BuyItem()
    {
        InventorySystem.instance.GetItem(ITEM_TYPE.Fish,FishLevel);
    }
    
}
