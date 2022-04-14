using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BerryTypeObject", menuName = "Scriptable Object/BerryTypeObject", order = int.MaxValue)]
public class Berry_type_object : ScriptableObject
{
    [SerializeField]
    private GameObject[] berry_type_prefab;
    public GameObject[] Berry_type_prefab { get { return berry_type_prefab; } }
}
