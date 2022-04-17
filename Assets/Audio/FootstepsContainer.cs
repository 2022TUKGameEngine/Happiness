using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Foot Steps Container", menuName = "Scriptable Object/Foot Steps Container", order = int.MaxValue)]
public class FootstepsContainer : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> footSteps_Grass;

    [SerializeField]
    private List<AudioClip> footSteps_Wood;

    public List<AudioClip> FootSteps_Grass { get { return footSteps_Grass; } }
    public List<AudioClip> FootSteps_Wood { get { return footSteps_Wood; } }

    [SerializeField]
    private List<AudioClip> itemSFX;

    public List<AudioClip> ItemSFX { get { return itemSFX; } }

}
