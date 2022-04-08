using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item Sprite Data", menuName = "Scriptable Object/Item Sprite Data", order = int.MaxValue)]
public class ItemSpriteData : ScriptableObject
{
    [SerializeField]
    private List<Sprite> itemSprites;
    public List<Sprite> ItemSprites { get { return itemSprites; } }

}
