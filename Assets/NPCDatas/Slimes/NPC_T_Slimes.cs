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

    //public RectTransform UIRotation;

    public Animator animator;
    public float speed;

    private void Start()
    {
        check = false;
        slimeMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        TalkBalloon = gameObject.GetComponentInChildren<TalkUI>();
        TalkBalloon.isTalking = false;
        quested = false;
        defaultSerifSystem = true;

        //UIRotation = gameObject.GetComponentInChildren<RectTransform>();
        //UIRotation.rotation = Quaternion.Euler(0, 360 - gameObject.transform.rotation.eulerAngles.y,0);

        animator.speed = speed;

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
            case 8:
                if (check) c = new Color(0.8f, 0.75f, 0.95f);
                NName.text = "�帰 ������";
                break;
            case 1:
            case 9:
                if (check) c = Color.white;
                NName.text = "�� ������";
                break;
            case 2:
            case 10:
                if (check) c = Color.red;
                NName.text = "���� ������";
                break;
            case 3:
            case 11:
                if (check) c = Color.green;
                NName.text = "�ʷ� ������";
                break;
            case 4:
            case 12:
                if (check) c = Color.blue;
                NName.text = "�Ķ� ������";
                break;
            case 5:
            case 13:
                if (check) c = Color.yellow;
                NName.text = "��� ������";
                break;
            case 6:
            case 14:
                if (check) c = Color.magenta;
                NName.text = "��ȫ ������";
                break;
            case 7:
            case 15:
                if (check) c = Color.cyan;
                NName.text = "�ϴ� ������";
                break;
            default:
                if (check) c = Color.black;
                NName.text = "� ������";
                break;
        }
        if (selector.Serifs.Count > SlimeNumber && SlimeNumber >= 0)
            serif = selector.Serifs[SlimeNumber];

        var newColorMaterial = Instantiate(slimeMeshRenderer.material);
        newColorMaterial.SetColor("_BaseColor", c);
        slimeMeshRenderer.material = newColorMaterial;
    }
}
