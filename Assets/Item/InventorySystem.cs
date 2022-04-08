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
        //print("GetItem Func");
        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i].itemType == type && inven[i].itemGrade == grade)
            {
                //print("Item plus");
                inven[i].changeNumber(num);
                return;
            }
        }
        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i].itemType == ITEM_TYPE.NONE)
            {
                //print("Item Add");
                inven[i].SetItem(type, grade, num);
                return;
            }
        }
    }

    public void SellItem(int invenNum, int sellNum)
    {
        inven[invenNum].changeNumber(-sellNum);
    }
}
