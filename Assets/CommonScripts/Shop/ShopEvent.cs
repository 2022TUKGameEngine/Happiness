using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvent : EventComponent
{
    public GameObject Shop;
    public GameObject ShopPanel;

    public ItemSpriteData ItemData;

    public int ItemDataNumber;


    public int ItemGrade;


    public override void TriggerEvent()
    {
        Shop.SetActive(true);
        ShopPanel.GetComponent<DragAndDrop>().ResetPos();

    }

    public void BuyItem()
    {
        if(CharacterManager.data._money>=ItemData.ItemPrices[ItemDataNumber])
        {
            InventorySystem.instance.GetItem((ITEM_TYPE)ItemDataNumber,0);
            CharacterManager.data.SpendMoney(ItemData.ItemPrices[ItemDataNumber]);
        }
    }

    public void FarmingLevelUp()
    {
        CharacterManager.data.EarnFarmingLevel();
    }
    public void MiningLevelUp()
    {
        CharacterManager.data.EarnMiningLevel();
    }

    public void FishingLevelUp()
    {
        CharacterManager.data.EarnFishingLevel();
    }

}
