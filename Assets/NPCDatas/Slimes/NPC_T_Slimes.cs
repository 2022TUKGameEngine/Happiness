using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_T_Slimes : NPC_Technologies
{
    public int SlimeNumber;

    private SkinnedMeshRenderer slimeMeshRenderer;

    public NPC_Slime_Selector selector;

    public Color c;
    private bool check;
    private bool defaultSerifSystem;

    private void Start()
    {
        check = false;
        slimeMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        TalkBalloon = gameObject.GetComponentInChildren<TalkUI>();
        TalkBalloon.isTalking = false;
        quested = false;
        defaultSerifSystem = true;

        ColorPacker();
    }

    override public void Evented(int seed)
    {
        if (defaultSerifSystem)
        {
            base.Evented(seed);
        }
        else
        {

            //�̽��� (����Ʈ ��)
            // if (!TalkBalloon.isTalking)
            // {
            //     progress = 0;
            //     TalkBalloon.openBalloon();
            // }
            // else
            // {
            //     progress++;
            // }

            // if (progress >= serif.RandomSerifs.Count)
            // {
            //     progress = 0;
            //     TalkBalloon.closeBalloon();
            //     serif.rand();
            //     return;
            // }

            // TalkBalloon.serif.text = serif.RandomSerifs[progress];
            
        }

    }

    private void ColorPacker()
    {
        if (c == new Color(0, 0, 0, 0))
        {
            check = true;
        }


        switch (SlimeNumber)
        {
            case 0:
                if (check) c = new Color(0.8f, 0.75f, 0.95f);
                NName.text = "�帰 ������";
                break;
            case 1:
                if (check) c = Color.white;
                break;
            case 2:
                if (check) c = Color.red;
                break;
            case 3:
                if (check) c = Color.green;
                break;
            case 4:
                if (check) c = Color.blue;
                break;
            case 5:
                if (check) c = Color.yellow;
                break;
            case 6:
                if (check) c = Color.magenta;
                break;
            case 7:
                if (check) c = Color.cyan;
                break;
            default:
                if (check) c = Color.black;
                break;
        }
        if (selector.Serifs.Count > SlimeNumber && SlimeNumber >= 0)
            serif = selector.Serifs[SlimeNumber];

        var newColorMaterial = Instantiate(slimeMeshRenderer.material);
        newColorMaterial.SetColor("_BaseColor", c);
        slimeMeshRenderer.material = newColorMaterial;
    }
}
