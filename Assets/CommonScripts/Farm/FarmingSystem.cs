using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Farm
{
    public VisualEffect berry;
    public int groundNum;
    public ITEM_TYPE farmedItem;
    public int grd;
    public int growthTime;  //0 - None, 1 < - exist, -1 - withered, -2 max
    public int maxGrowthTime;
    public bool isWateredToday;
    public int thisPlantDead;
    public Farm() { }
    public Farm(VisualEffect _s, int _g, ITEM_TYPE _i, int _grd, int _gT)
    {
        berry = _s;
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
                berry.SetFloat("LifetimeBush", growthTime < maxGrowthTime/2f ? growthTime / (maxGrowthTime / 2f) : 1f);
                berry.SetFloat("LifetimeBerry", growthTime < maxGrowthTime/2f ? 0 : (growthTime - maxGrowthTime/2f) / (maxGrowthTime / 2f));
                //berry.SetFloat("LifetimeBush", (float)growthTime / maxGrowthTime);
                //berry.SetFloat("LifetimeBerry", (float)growthTime / maxGrowthTime); 

                if (growthTime >= maxGrowthTime)
                {
                    berry.SetFloat("LifetimeBush", 1f);
                    berry.SetFloat("LifetimeBerry",1f);
                    Debug.Log("Finish");
                    growthTime = -2;
                }
            }
        }
    }

    public void getItem()
    {
        InventorySystem.instance.GetItem(farmedItem, grd);
        SoundManager.instance.getItem();
    }
}

public class FarmingSystem : MonoBehaviour
{
    public static FarmingSystem instance;

    public Berry_type_object Bto;
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

    public void plantSeed(GameObject s, int groundNum)
    {
        int days = Random.Range(1, 4) - (CharacterManager.data._level/2);
        if (days < 1) days = 1;
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

        days += grd - (CharacterManager.data._level/4);
        if (days < 1)
            days = 1;
        
        ITEM_TYPE seed = ITEM_TYPE.Berry;
        print("plant : " + grd);

        GameObject berry = Instantiate(Bto.Berry_type_prefab[grd-1], s.transform.position, Quaternion.identity);
        berry.transform.parent = s.transform;
        currentUseGrounds.Add(new Farm(berry.GetComponentInChildren<VisualEffect>(), groundNum, seed, grd, days));
    }

    public void clearGround(int groundNum)
    {
        print("clear!");
        foreach(var f in currentUseGrounds)
        {
            if (f.growthTime < 0)
            {
                if (f.growthTime == -2)
                {
                    f.getItem();
                }
                f.berry.SetFloat("LifetimeBush", 0f);
                f.berry.SetFloat("LifetimeBerry", 0f);
                Destroy(f.berry.transform.parent.gameObject);
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
