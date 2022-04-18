using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    public ItemData[] inven;

    void Awake()
    {
        instance = this;
    }
    
    public void GetItem(ITEM_TYPE type, int grade, int num = 1)
    {
        if (type == ITEM_TYPE.NONE)
        {
            return;
        }
        //print("GetItem Func");
        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i].itemType == type && inven[i].itemGrade == grade)
            {
                //print("Item plus");
                inven[i].changeNumber(num);
                SoundManager.instance.getItem();
                return;
            }
        }
        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i].itemType == ITEM_TYPE.NONE)
            {
                //print("Item Add");
                inven[i].SetItem(type, grade, num);
                SoundManager.instance.getItem();
                return;
            }
        }
        
    }

    public void SellItem(int invenNum, int sellNum)
    {
        inven[invenNum].changeNumber(-sellNum);
        SoundManager.instance.sellItem();
    }

    public bool useItem(ITEM_TYPE it)
    {
        int invenNum = -1;
        foreach(var item in inven)
        {
            if(item.itemType == it)
            {
                invenNum = System.Array.IndexOf(inven,item);
                break;
            }
        }
        if (invenNum == -1)
        {
            return false;
        }
        inven[invenNum].changeNumber(-1);
        return true;
    }
}
