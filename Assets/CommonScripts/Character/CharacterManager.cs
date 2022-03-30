using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    public Image HPBar;

    public float PlayerMAXHP;
    public float PlayerHP;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMAXHP = 100;
        PlayerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP -= Time.deltaTime;
        UIReflect();
    }

    void UIReflect()
    {
        HPBar.fillAmount = PlayerHP / PlayerMAXHP;
    }
}
