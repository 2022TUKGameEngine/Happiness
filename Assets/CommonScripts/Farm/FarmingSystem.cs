using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    public int groundNum;
    public ITEM_TYPE farmedItem;
    public int growthTime;  //0 - None, 1 < - exist, -1 - withered
    public bool isWateredToday;
    public int thisPlantDead;
    public Farm() { }
    public Farm(int _g, ITEM_TYPE _i, int _gT, bool _w)
    {
        thisPlantDead = 0;
        groundNum = _g;
        farmedItem = _i;
        growthTime = _gT;
        isWateredToday = _w;
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
                growthTime = -1;
                return;
            }
            else
            {
                growthTime++;
                isWateredToday = false;

                //완성 처리, 초기화
                {
                    //thisPlantDead = -1;
                }
            }
        }
    }
}

public class FarmingSystem : MonoBehaviour
{
    private List<Farm> currentUseGrounds = new List<Farm>();

    public void dayUpdate()
    {
        foreach(var g in currentUseGrounds)
        {
            g.newDay();
        }
    }

    public void watering(int groundNum)
    {

        currentUseGrounds[groundNum].Watering();
    }

    public void plantSeed(int groundNum, ITEM_TYPE seed)
    {
        currentUseGrounds.Add(new Farm(groundNum, seed, 1, false));
    }
}
