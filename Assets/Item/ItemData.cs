using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemData : MonoBehaviour
{
    public ITEM_TYPE itemType { get { return (ITEM_TYPE)PlayerPrefs.GetInt("InventoryType"+inventoryIndex, (int)ITEM_TYPE.NONE); }
                                 set { PlayerPrefs.SetInt("InventoryType"+inventoryIndex, (int)value); } }

    public int itemGrade { get { return PlayerPrefs.GetInt("InventoryGrade"+inventoryIndex, 0); } 
                            set { PlayerPrefs.SetInt("InventoryGrade"+inventoryIndex, value); } }

    public ItemSpriteData itemSprite;
    public Sprite ItemSprite { get { return itemSprite.ItemSprites[(int)itemType+itemGrade]; } }

    public string itemName { get { return itemSprite.ItemNames[(int)itemType+itemGrade]; } }


    public int itemPrice { get { return itemSprite.ItemPrices[(int)itemType+itemGrade]; } }


    public bool isAlchemicable { get { return itemSprite.IsAlchemicables[(int)itemType+itemGrade]; } }

    Image selfImage;

    public int numbers { get { return PlayerPrefs.GetInt("InventoryNumbers"+inventoryIndex, 0); } 
                            set { PlayerPrefs.SetInt("InventoryNumbers"+inventoryIndex, value); } }
    TMP_Text txt_numbers;

    public int inventoryIndex;

    public GameObject SellingPriceImage;

    void Start()
    {
        selfImage = GetComponent<Image>();
        selfImage.sprite = ItemSprite;
        //print((int)itemType+itemGrade);
        txt_numbers = GetComponentInChildren<TMP_Text>();

        if (numbers>0)
            txt_numbers.text = numbers.ToString();
        else
            txt_numbers.text = "";

    }

    public void SetItem(ITEM_TYPE type, int grade, int num=-1)
    {
        itemType = type;
        itemGrade = grade;
        selfImage.sprite = ItemSprite;
        if(num != -1)
        {
            numbers = num;
        }
        if (numbers>0)
            txt_numbers.text = numbers.ToString();
        else
            txt_numbers.text = "";
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
            selfImage.sprite = ItemSprite;
        }
        else
        {
            txt_numbers.text = numbers.ToString();
        }
    }

    public void SellItem()
    {
        //print(itemType);
        if (itemType == ITEM_TYPE.NONE)
            return;
            
        if(itemType==ITEM_TYPE.EnergyDrink || itemType==ITEM_TYPE.EnergyBar)
        {
            CharacterManager.data.SpendMoney(itemPrice);
            CharacterManager.data.ChangeStress(-50);
        }

        if (isAlchemicable)
        {
            if (numbers > 0)
            {
                CharacterManager.data.EarnMoney(itemPrice);
                changeNumber(-1);
            }
        }
        else
        {
            if (numbers > 0)
            {
                CharacterManager.data.EarnMoney(Random.Range(10,80)*itemPrice*itemPrice);
                changeNumber(-1);
            }
        }

        SoundManager.instance.sellItem();
    }

    public void On_MouseEnter()
    {
        //print("enter");
        if (itemType == ITEM_TYPE.NONE)
            return;
       
        if (isAlchemicable)
            SellingPriceImage.GetComponentInChildren<TMP_Text>().text = itemPrice.ToString();
        else
            SellingPriceImage.GetComponentInChildren<TMP_Text>().text = (Random.Range(50,100)*itemPrice*itemPrice).ToString();
        SellingPriceImage.SetActive(true);
    }

    public void On_MouseExit()
    {
        SellingPriceImage.SetActive(false);
    }
}
