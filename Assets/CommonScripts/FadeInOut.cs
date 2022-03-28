using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    private bool isFade = false;
    private Image fadeImage;
   
    public float fAnimSpeed = 2f;
    private float fStart = 0f;
    private float fEnd = 1f;
    private float fTime = 0f; 
    private Color fadeColor;
    private bool isFadeIn = true;

    private void Awake() 
    {
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
    }

    void OnTriggerStay(Collider coll)
    {
        if(IsFadeStart(ref coll))
        {
            StartCoroutine("FadeInPlay");
        }
    }

    bool IsFadeStart(ref Collider coll)
    {
        if (!coll.CompareTag("Player")) {return false;}
        if (!Input.GetKeyUp(KeyCode.Q)) {return false;}
        if (isFade) {return false;}
    
        return true;
    }

    IEnumerator FadeInPlay()
    {
        InitFade();

        WaitForSeconds wait = new WaitForSeconds(0.01f);
        while (IsFadeEnd())
        {
            UpdateFadeImageAlpha();
            yield return wait;
        }

        isFadeIn = !isFadeIn;
        isFade = false;
        if (!isFadeIn)
        {
            StartCoroutine("FadeInPlay");
        }
    }

    bool IsFadeEnd()
    {
        bool isColoring = (isFadeIn) ? fadeColor.a < fEnd : fadeColor.a > fEnd;
        return (isColoring) ? true : false;
    }

    void InitFade()
    {
        isFade = true;
        fadeColor = fadeImage.color;
        fStart = (isFadeIn) ? 0f : 1f;
        fEnd = (isFadeIn) ? 1f : 0f;
        fTime = 0f;
    }

    void UpdateFadeImageAlpha()
    {
        fTime += Time.deltaTime / fAnimSpeed;
        fadeColor.a = Mathf.Lerp(fStart, fEnd, fTime);
        fadeImage.color = fadeColor;
    }
}
