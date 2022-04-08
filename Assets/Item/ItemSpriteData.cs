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

[CreateAssetMenu(fileName = "Item Sprite Data", menuName = "Scriptable Object/Item Sprite Data", order = int.MaxValue)]
public class ItemSpriteData : ScriptableObject
{
    [SerializeField]
    private Sprite[] itemSprites;
    public Sprite[] ItemSprites { get { return itemSprites; } }

    [SerializeField]
    private string[] itemNames;
    public string[] ItemNames { get { return itemNames; } }


    [SerializeField]
    private int[] itemPrices;
    public int[] ItemPrices { get { return itemPrices; } }

    [SerializeField]
    private bool[] isAlchemicables;
    public bool[] IsAlchemicables { get { return isAlchemicables; } }

}
