using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    
    private bool fadeOut, fadeIn;
    public float fadeSpeed;

    [SerializeField] private Image objectToFade;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(FadeOutObject());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FadeInObject());
        } 

        //if (fadeOut)
        //{
        //    Color objectColor = objectToFade.color;
        //    float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

        //    objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        //    objectToFade.material.color = objectColor;

        //    if (objectColor.a <= 0)
        //    {
        //        fadeOut = false;
        //    }
        //}
    }

    public void FadeScreen(bool isFadingIn)
    {
        if (isFadingIn)
        {
            StartCoroutine(FadeInObject());
        }
        else
        {
            StartCoroutine(FadeOutObject());
        }
    }

    public IEnumerator FadeOutObject()
    {
        while (objectToFade.color.a > 0)
        {
            Color objectColor = objectToFade.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            objectToFade.color = objectColor;
            yield return null;
        }
    }

    public IEnumerator FadeInObject()
    {
        while (objectToFade.color.a > 0)
        {
            Color objectColor = objectToFade.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            objectToFade.color = objectColor;
            yield return null;
        }

    }
}
