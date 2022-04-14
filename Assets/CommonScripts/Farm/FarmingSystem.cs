using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    public int groundNum;
    public ITEM_TYPE farmedItem;
    public int grd;
    public int growthTime;  //0 - None, 1 < - exist, -1 - withered, -2 max
    public int maxGrowthTime;
    public bool isWateredToday;
    public int thisPlantDead;
    public Farm() { }
    public Farm(int _g, ITEM_TYPE _i, int _grd, int _gT)
    {
        thisPlantDead = 0;
        groundNum = _g;
        grd = _grd;
        farmedItem = _i;
        growthTime = 1;
        maxGrowthTime = _gT+1;
        isWateredToday = false;
    }

    public void Watering()
    {
        if (isWateredToday)
        {
            thisPlantDead = 1;
        }
        else
        {
            isWateredToday = true;
        }
    }

    public void newDay()
    {
        if (growthTime > 0)
        {
            if (thisPlantDead == 1 || !isWateredToday)
            {
                Debug.Log("Dead!");
                growthTime = -1;
                return;
            }
            else
            {
                growthTime++;
                isWateredToday = false;

                if (growthTime >= maxGrowthTime)
                {
                    Debug.Log("Finish");
                    growthTime = -2;
                }
            }
        }
    }

    public void getItem()
    {
        InventorySystem.instance.GetItem(farmedItem, grd);
    }
}

public class FarmingSystem : MonoBehaviour
{
    public static FarmingSystem instance;
    private List<Farm> currentUseGrounds = new List<Farm>();

    private void Start()
    {
        instance = this;
    }

    public void dayUpdate()
    {
        print("daytime");
        foreach(var g in currentUseGrounds)
        {
            g.newDay();
        }
    }

    public void watering(int groundNum)
    {
        foreach(var g in currentUseGrounds)
        {
            if (g.groundNum == groundNum)
            {
                print("water!");
                g.Watering();
                return;
            }
        }
    }

    public void plantSeed(int groundNum)
    {
        int days = Random.Range(3, 3) - (CharacterManager.data._level/2);
        int grd = Random.Range(1,100) + CharacterManager.data._level;
        if (grd > 97)
        {
            grd = 4;
        }
        else if (grd > 88)
        {
            grd = 3;
        }
        else if (grd > 55)
        {
            grd = 2;
        }
        else
        {
            grd = 1;
        }

        if (days < grd)
            days = grd - (CharacterManager.data._level/3);
        if (days < 1)
            days = 1;
        
        ITEM_TYPE seed = ITEM_TYPE.Berry;
        print("plant : " + grd);
        currentUseGrounds.Add(new Farm(groundNum, seed, grd, days));
    }

    public void clearGround(int groundNum)
    {
        print("clear!");
        foreach(var f in currentUseGrounds)
        {
            if (f.growthTime == -2)
            {
                f.getItem();
            }
        }
        currentUseGrounds.Remove(currentUseGrounds.Find(x => x.groundNum == groundNum));
    }

    public int isGroundFarmed(int groundNum)
    {
        foreach(var f in currentUseGrounds)
        {
            if (f.groundNum == groundNum && f.growthTime > 0)
            {
                return 1;
            }
            else if (f.groundNum == groundNum && f.growthTime < 0)
            {
                return -1;
            }
        }
        return 0;
    }
}
