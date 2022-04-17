using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource foot;
    public AudioSource SFXs;

    public FootstepsContainer FSC;

    private void Start()
    {
        instance = this;
    }

    public void step(int i)
    {
        switch(i)
        {
            case 1:
            playFootStep(FSC.FootSteps_Grass[Random.Range(0, FSC.FootSteps_Grass.Count)]);
            break;

            case 2:
            playFootStep(FSC.FootSteps_Wood[Random.Range(0, FSC.FootSteps_Wood.Count)]);
            break;
        }
    }

    public void playFootStep(AudioClip ac)
    {
        foot.clip = ac;
        foot.pitch = Random.Range(0.8f, 1.2f);
        foot.Play();
    }

    public void getItem()
    {
        SFXs.clip = FSC.ItemSFX[0];
        SFXs.Play();
    }

    public void sellItem()
    {
        SFXs.clip = FSC.ItemSFX[Random.Range(1, FSC.ItemSFX.Count)];
        SFXs.pitch = Random.Range(0.8f, 1.2f);
        SFXs.Play();
    }
}
