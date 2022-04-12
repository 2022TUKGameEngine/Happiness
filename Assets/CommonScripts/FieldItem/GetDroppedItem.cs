using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetDroppedItem : MonoBehaviour
{
    public ITEM_TYPE type;
    public int grade;
    public int nums;

    private UnityEvent deleteItem = new UnityEvent();

    GetDroppedItem(){}
    public void init(ITEM_TYPE type, int grade, int num, UnityAction callback)
    {
        this.type = type;
        this.grade = grade;
        this.nums = num;
        deleteItem.AddListener(callback);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InventorySystem.instance.GetItem(type, grade, nums);
        }
        deleteItem.Invoke();
        Destroy(gameObject);
    }
}
