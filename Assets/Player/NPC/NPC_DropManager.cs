using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Drops
{
    public List<GameObject> NPCs;
}

public class NPC_DropManager : MonoBehaviour
{
    public DayNightCycle TimeLapsed;
    public List<Drops> drops;

    void Start()
    {
        for (int i = 0; i < drops.Count; i++)
        {
            foreach (var v in drops[i].NPCs)
            {
                if (i == 0)
                    v.SetActive(true);
                else
                    v.SetActive(false);
            }
        }
    }

    public void changeNPCByDay()
    {
        if (TimeLapsed.dayNumber < drops.Count)
        {
            foreach (var v in drops[TimeLapsed.dayNumber - 1].NPCs)
            {
                v.SetActive(false);
            }
            foreach (var v in drops[TimeLapsed.dayNumber].NPCs)
            {
                v.SetActive(true);
            }
        }
    }
}
