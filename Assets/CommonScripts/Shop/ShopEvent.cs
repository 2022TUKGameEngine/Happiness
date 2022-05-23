using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvent : EventComponent
{
    public GameObject Shop;
    public GameObject ShopPanel;


    public int ItemGrade;


    public override void TriggerEvent()
    {
        Shop.SetActive(true);
        ShopPanel.GetComponent<DragAndDrop>().ResetPos();

    }

    public void BuyItem()
    {
        InventorySystem.instance.GetItem(ITEM_TYPE.Fish,ItemGrade);
    }

    public void BuyBait()
    {
        InventorySystem.instance.GetItem(ITEM_TYPE.Bait,0);
    }

    public void BuySeed()
    {
        InventorySystem.instance.GetItem(ITEM_TYPE.Seed,0);
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
