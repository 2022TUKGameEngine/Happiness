using UnityEngine;

public enum ITEM_TYPE
{
    NONE = 0,
    Fish,
    Fish_Normal,
    Fish_Rare,
    Fish_SuperRare,
    Fish_Legend,
}

[CreateAssetMenu(fileName = "Item Numeric Data", menuName = "Scriptable Object/Item Numeric Data", order = int.MaxValue)]
public class ItemNumericData : ScriptableObject
{
    [SerializeField]
    private ITEM_TYPE itemType;
    public ITEM_TYPE ItemType { get { return itemType; } }
    
    public ItemSpriteData itemSprite;
    public Sprite ItemSprite { get { return itemSprite.ItemSprites[(int)ItemType]; } }

    [SerializeField]
    private string itemName;
    public string ItemName { get { return itemName; } }

    [SerializeField]
    private int itemPrice;
    public int ItemPrice { get { return itemPrice; } }


    [SerializeField]
    private bool isAlchemicable;
    public bool IsAlchemicable { get { return isAlchemicable; } }

}
