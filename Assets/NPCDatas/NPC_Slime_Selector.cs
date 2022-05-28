using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPC_Slime_Selector", menuName = "Scriptable Object/NPC/Selector", order = int.MaxValue)]
public class NPC_Slime_Selector : ScriptableObject
{
    [SerializeField]
    private List<NPC_Serifs> serif;

    public List<NPC_Serifs> Serifs
    {
        get
        {
            return serif;
        }
    } 
}
