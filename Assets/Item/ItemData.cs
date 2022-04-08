using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ITEM_TYPE
{
    NONE = 0,
    Fish,
    Fish_Normal,
    Fish_Rare,
    Fish_SuperRare,
    Fish_Legend,
}

public class ItemData : MonoBehaviour
{
    [SerializeField]
    private ITEM_TYPE itemType { get { return (ITEM_TYPE)PlayerPrefs.GetInt("InventoryType"+inventoryIndex, 0); }
                                 set { PlayerPrefs.SetInt("InventoryType"+inventoryIndex, (int)value); } }

    [SerializeField]
    private int itemGrade { get { return PlayerPrefs.GetInt("InventoryGrade"+inventoryIndex, 0); } 
                            set { PlayerPrefs.SetInt("InventoryGrade"+inventoryIndex, value); } }

    public ItemSpriteData itemSprite;
    public Sprite ItemSprite { get { return itemSprite.ItemSprites[(int)itemType+itemGrade]; } }

    [SerializeField]
    private string itemName { get { return itemSprite.ItemNames[(int)itemType+itemGrade]; } }

    [SerializeField]
    private int itemPrice { get { return itemSprite.ItemPrices[(int)itemType+itemGrade]; } }

    [SerializeField]
    private bool isAlchemicable { get { return itemSprite.IsAlchemicables[(int)itemType+itemGrade]; } }

    Image selfImage;

    public int numbers;
    TMP_Text txt_numbers;

    public int inventoryIndex;

    void Start()
    {
        selfImage = GetComponent<Image>();
        selfImage.sprite = ItemSprite;
        //print((int)itemType+itemGrade);
        txt_numbers = GetComponentInChildren<TMP_Text>();
        txt_numbers.text = "";
    }

    public void SetItem(ITEM_TYPE type, int grade, int num=-1)
    {
        itemType = type;
        itemGrade = grade;
        if(num != -1)
        {
            numbers = num;
        }
        txt_numbers.text = numbers.ToString();
    }

    public void changeNumber(int plus)
    {
        numbers += plus;
        if (numbers <= 0)
        {
            itemType = ITEM_TYPE.NONE;
            itemGrade = 0;
            numbers = 0;
            txt_numbers.text = "";
        }
        else
        {
            txt_numbers.text = numbers.ToString();
        }
    }
}
