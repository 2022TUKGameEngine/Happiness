using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item Sprite Data", menuName = "Scriptable Object/Item Sprite Data", order = int.MaxValue)]
public class ItemSpriteData : ScriptableObject
{
    [SerializeField]
    private List<Sprite> itemSprites;
    public List<Sprite> ItemSprites { get { return itemSprites; } }

    [SerializeField]
    private List<string> itemNames;
    public List<string> ItemNames { get { return itemNames; } }


    [SerializeField]
    private List<int> itemPrices;
    public List<int> ItemPrices { get { return itemPrices; } }

    [SerializeField]
    private List<bool> isAlchemicables;
    public List<bool> IsAlchemicables { get { return isAlchemicables; } }

}
