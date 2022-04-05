using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    public Image HPBar;

    public float PlayerHP;
    public float Money;
    public float Level;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UIReflect();
    }

    void UIReflect()
    {
        if (HPBar)
        {
            HPBar.fillAmount = PlayerHP / 50;
            HPBar.color = new Color(HPBar.fillAmount, 0, 0);
        }
    }
}
