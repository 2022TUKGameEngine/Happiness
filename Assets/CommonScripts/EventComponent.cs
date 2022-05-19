using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
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

        case "NPC":
            gameObject.GetComponent<NPC_Technologies>().Evented(Random.Range(0,100));
            //Debug.Log("workman");
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

    public void BuyBait()
    {
        InventorySystem.instance.GetItem(ITEM_TYPE.Bait,0);
    }
    
}
