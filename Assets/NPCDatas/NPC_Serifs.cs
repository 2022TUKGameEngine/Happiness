using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class _serif
{
    public List<string> s;

}

[CreateAssetMenu(fileName = "NPC_Serifs", menuName = "Scriptable Object/NPC/Serifs", order = int.MaxValue)]
public class NPC_Serifs : ScriptableObject
{
    [SerializeField]
    private List<_serif> randomSerifs;

    private int randomSerifSelector = 0;

    [SerializeField]
    private List<string> questSerifs;

    [SerializeField]
    private List<string> resultSerifs;

    public void rand()
    {
        randomSerifSelector = Random.Range(0, randomSerifs.Count);
    }

    public List<string> RandomSerifs { get { return randomSerifs[randomSerifSelector].s; } }
    public List<string> QuestSerifs { get { return questSerifs; } }

    public List<string> ResultSerifs { get { return resultSerifs; } }

}
