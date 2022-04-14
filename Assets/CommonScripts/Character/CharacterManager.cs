using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class CharacterManager : MonoBehaviour
{
    static public CharacterManager data;
    public GameObject statusPackage;
    public GameObject inventory;
    private bool inventoryOpened;
    public Image HPBar;
    public TMP_Text Money;
    public TMP_Text Level;

    public float PlayerHP;
    public int _money;
    public int _level;

    private Collider detectedCollider = null;

    public int debug_grade;

    void OnStatus(InputValue value)
    {
        if(value.Get<float>() > 0f)
        {

            if (statusPackage.activeSelf)
            {
                statusPackage.SetActive(false);
            }
            else
            {
                statusPackage.SetActive(true);
            }
        }
    }

    void OnInteraction(InputValue value)
    {
        if(value.Get<float>() > 0f)
        {
            if (detectedCollider != null)
            {
                detectedCollider.gameObject.GetComponent<EventComponent>().TriggerEvent();
            }
        }
    }
    void OnInventory(InputValue value)
    {
        if(inventoryOpened)
        {
            inventory.GetComponent<Animator>().SetTrigger("CloseInventory");
            inventoryOpened = false;
        }
        else
        {
            inventory.GetComponent<Animator>().SetTrigger("OpenInventory");
            inventoryOpened = true;
        }
    }

    void Awake()
    {
        data = this;
    }

    void Start()
    {
        PlayerHP = 50;
        inventoryOpened = false;
    }

    void Update()
    {
        if (HPBar)
        {
            HPBar.fillAmount = PlayerHP / 200f;
            HPBar.color = new Color(HPBar.fillAmount, 0, 0);
        }

        Money.text = _money.ToString();
        Level.text = _level.ToString();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("EventCollider"))
        {
            detectedCollider = collision;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EventCollider"))
        {
            if (detectedCollider == other)
            {
                detectedCollider = null;
            }
        }
    }

    
    void OnDebugStage(InputValue value)
    {
        if(value.Get<float>() > 0f)
        {
            if(DebugMode.instance.debugMode)
            {
                InventorySystem.instance.GetItem(ITEM_TYPE.Fish,debug_grade,1);
            }
        }
    }

    public void EarnHP(int hp)
    {
        PlayerHP += hp;
        if(PlayerHP > 200)
        {
            PlayerHP = 200;
        }
    }

    public void LoseHP(int hp)
    {
        PlayerHP-=hp;
        if(PlayerHP<=0)
        {
            PlayerHP=0;
        }
    }

    public void EarnMoney(int money)
    {
        _money += money;
    }

    public void EarnLevel(int level)
    {
        _level += level;
    }

}
