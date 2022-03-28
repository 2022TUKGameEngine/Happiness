using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    private bool isFade = false;
    private Image fadeImage;
   
    public float animSpeed = 2f;
    private float fStart = 0f;
    private float fEnd = 1f;
    private float fTime = 0f; 

    private void Awake() 
    {
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
    }

    void OnTriggerStay(Collider coll)
    {
        if(IsFadeStart(ref coll))
        {
            StartCoroutine(FadeInPlay(true));
        }
    }

    bool IsFadeStart(ref Collider coll)
    {
        if (!coll.CompareTag("Player")) {return false;}
        if (!Input.GetKeyUp(KeyCode.Q)) {return false;}
        if (isFade) {return false;}
    
        return true;
    }

    IEnumerator FadeInPlay(bool isFadeIn)
    {
        isFade = true;

        Color fadeColor = fadeImage.color;
        fStart = (isFadeIn) ? 0f : 1f;
        fEnd = (isFadeIn) ? 1f : 0f;
        fTime = 0f;
        fadeColor.a = Mathf.Lerp(fStart, fEnd, fTime);

        while (IsFadeEnd(ref fadeColor,isFadeIn))
        {
            fTime += Time.deltaTime/fAnimSpeed;
            fadeColor.a = Mathf.Lerp(fStart, fEnd, fTime);
            fadeImage.color = fadeColor;

            yield return null;
        }

        isFade = false;
        if (isFadeIn){StartCoroutine(FadeInPlay(false));}

    }

    bool IsFadeEnd(ref Color color, bool isFadeIn)
    {
        if (isFadeIn)
        {
            return (color.a < fEnd) ? true : false;
        }
        else
        {
            return (color.a > fEnd) ? true : false;
        }
    }
}
