using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpace : MonoBehaviour
{
    public int spaceID;
    public List<ITEM_TYPE> dropItemTypes;
    public List<int> dropItemRatio;


    public (ITEM_TYPE,int) whichItemDrop(GameObject item)
    {
        
        return (ITEM_TYPE.Fish,1);
    }
    
}
