using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpace : MonoBehaviour
{
    public int spaceID;
    public List<ITEM_TYPE> dropItemTypes;
    public List<int> dropItemGrades;
    public List<int> dropItemRatio;

    private float AccumulatedRatio;

    private void Awake()
    {
        if (dropItemTypes.Count != dropItemGrades.Count || dropItemTypes.Count != dropItemRatio.Count)
        {
            Debug.LogError("ItemDropSpace.cs: dropItemTypes, dropItemGrades, dropItemRatio must have same length.");
        }

        AccumulatedRatio = 0;
        foreach (var r in dropItemRatio)
        {
            AccumulatedRatio += r;
        }
    }


    public (ITEM_TYPE,int) whichItemDrop(GameObject item)
    {
        float gachaCatcher = Random.Range(0, AccumulatedRatio);
        foreach(var r in dropItemRatio)
        {
            if (gachaCatcher < r)
            {
                return (dropItemTypes[dropItemRatio.IndexOf(r)], dropItemGrades[dropItemRatio.IndexOf(r)]);
            }
            gachaCatcher -= r;
        }
        return (dropItemTypes[dropItemRatio.Count - 1], dropItemGrades[dropItemRatio.Count - 1]);
    }
    
}
