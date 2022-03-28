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
        isFade = true;

        Color fadeColor = fadeImage.color;
        fTime = 0f;

        while (fadeColor.a < fEnd)
        {
            fTime += Time.deltaTime/animSpeed;
            fadeColor.a = Mathf.Lerp(fStart, fEnd, fTime);
            fadeImage.color = fadeColor;

            yield return null;
        }

        isFade = false;
    }
}
