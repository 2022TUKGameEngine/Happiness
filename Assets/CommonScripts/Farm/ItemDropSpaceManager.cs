using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpaceManager : MonoBehaviour
{
    public GameObject dropItemPrefab;
    public List<GameObject> dropSpaces;

    private BoxCollider area;

    public int spawnedItemNums;
    public int spawnedItemNumMax;

    void Start()
    {
        //DEBUG
        itemDrop(0);
    }

    public void itemDrop(int space)
    {
        if (spawnedItemNums < spawnedItemNumMax)
        {
            area = dropSpaces[space].GetComponent<BoxCollider>();

            var drops = dropSpaces[space].GetComponent<ItemDropSpace>().whichItemDrop(dropItemPrefab);
            Instantiate(dropItemPrefab, GetRandomPosition(), Quaternion.identity).GetComponent<GetDroppedItem>().init(drops.Item1,drops.Item2, 1, () => { spawnedItemNums--; });
            spawnedItemNums++;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = area.transform.position;
        Vector3 size = area.size;
        
        float posX = basePosition.x + Random.Range(-size.x/2f, size.x/2f);
        float posY = basePosition.y + Random.Range(-size.y/2f, size.y/2f);
        float posZ = basePosition.z + Random.Range(-size.z/2f, size.z/2f);
        
        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        
        return spawnPos;
    }

}
