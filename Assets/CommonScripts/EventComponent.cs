using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventComponent : MonoBehaviour
{
    public string EventType;
    public GameManager GameStatus;
    public CharacterManager CharacterStatus;
    public Animator Animation;
    private bool BreakerIn=false;
    
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
                CharacterManager.data.ChangeStress(10);

            }
            else if (FarmingSystem.instance.isGroundFarmed(groundNum) == 0)
            {
                if (CharacterManager.data.inventory.GetComponent<InventorySystem>().useItem(ITEM_TYPE.Seed))
                {
                    FarmingSystem.instance.plantSeed(gameObject, groundNum);
                    CharacterManager.data.ChangeStress(10);

                }
            }
            else
            {
                FarmingSystem.instance.clearGround(groundNum);
                CharacterManager.data.ChangeStress(10);
            }

            break;
        

        case "NPC":
            gameObject.GetComponent<NPC_Technologies>().Evented(Random.Range(0,100));
            //Debug.Log("workman");
            break;

        case "Breaker":
            if(CharacterManager.data._money>50 && BreakerIn==false)
            {
                CharacterManager.data.SpendMoney(50);
                BreakerIn=true;
                Animation.SetBool("IsOpen",true);
            }

            else if(BreakerIn==true)
            {
                BreakerIn=false;
                Animation.SetBool("IsOpen",true);
            }

            break;

        case "Digging":
            Debug.Log("dig");
            CharacterMove.data.dig = 50;
            StartCoroutine(CharacterMove.data.digPanel());
            Animation.SetBool("isDigging",true);
        break;
        }
    }


    protected virtual void Update() 
    {
    }    
}
