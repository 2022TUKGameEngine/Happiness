using UnityEngine;



[CreateAssetMenu(fileName = "Item Numeric Data", menuName = "Scriptable Object/Item Numeric Data", order = int.MaxValue)]
public class ItemNumericData : ScriptableObject
{
    [SerializeField]
    private ITEM_TYPE itemType;
    public ITEM_TYPE ItemType { get { return itemType; } }

    [SerializeField]
    private int itemGrade;
    public int ItemGrade { get { return itemGrade; } }
    
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
