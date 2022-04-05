using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class CharacterManager : MonoBehaviour
{
    public GameObject statusPackage;
    public Image HPBar;
    public TMP_Text Money;
    public TMP_Text Level;

    public float PlayerHP;
    public float _money;
    public float _level;

    private Collider detectedCollider = null;

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

//     public void OnStatus(InputAction.CallbackContext context)
//  {
     
//      if (context.started)
//      {
//          Debug.Log("Tab2");
//          //button is press
//      }
//      else if (context.canceled)
//      {
//          Debug.Log("Tab3");
//          //button is released
//      }
//  }

    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = 50;
    }

    // Update is called once per frame
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

}
