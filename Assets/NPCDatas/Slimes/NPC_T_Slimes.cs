using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_T_Slimes : NPC_Technologies
{
    public int SlimeNumber;
    private SkinnedMeshRenderer slimeMeshRenderer;

    public Color c;
    private bool check;

    private void Start()
    {
        check = false;
        slimeMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        TalkBalloon = gameObject.GetComponentInChildren<TalkUI>();
        TalkBalloon.isTalking = false;
        quested = false;

        ColorPacker();
    }

    override public void Evented(int seed)
    {
        TalkBalloon.serif.text = serif.RandomSerifs[progress];
    }

    private void ColorPacker()
    {
        if (c == Color.black)
        {
            check = true;
        }

        switch(SlimeNumber)
        {
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

        var newColorMaterial = Instantiate(slimeMeshRenderer.material);
        newColorMaterial.SetColor("_BaseColor", c);
        slimeMeshRenderer.material = newColorMaterial;
    }
}
