using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 0.1f;
    public float fadeWaitTime = 1;
    public bool fadeInOutOnAwake = false;

    // Start is called before the first frame update
    void Start()
    {
        if (fadeInOutOnAwake)
        {
            StartCoroutine("FadeIn");
            StartCoroutine("FadeWait");
        }
    }

    public void FadeIn_func()
    {
        StartCoroutine("FadeIn");
    }

    public void FadeOut_func()
    {
        StartCoroutine("FadeOut");
    }

    bool haveSpriteRenderer;
    IEnumerator FadeIn()
    {
        Color color;
        if (!(this.gameObject.GetComponent<SpriteRenderer>() != null)) haveSpriteRenderer = false;
        if (haveSpriteRenderer)
        {
            color = this.gameObject.GetComponent<SpriteRenderer>().color;
            while (color.a < 1f)
            {
                color = this.gameObject.GetComponent<SpriteRenderer>().color;

                this.gameObject.GetComponent<SpriteRenderer>().color
                = new Color(color.r, color.g, color.b, color.a + 0.1f);

                yield return new WaitForSeconds(fadeSpeed);
            }
            this.gameObject.GetComponent<SpriteRenderer>().color
                = new Color(color.r, color.g, color.b, 1);
        }
        else
        {
            color = this.gameObject.GetComponent<Image>().color;
            while (color.a < 1f)
            {
                color = this.gameObject.GetComponent<Image>().color;

                this.gameObject.GetComponent<Image>().color
                = new Color(color.r, color.g, color.b, color.a + 0.1f);

                yield return new WaitForSeconds(fadeSpeed);
            }
            this.gameObject.GetComponent<Image>().color
                = new Color(color.r, color.g, color.b, 1);
        }
    }

    IEnumerator FadeOut()
    {
        Color color;
        if (!(this.gameObject.GetComponent<SpriteRenderer>() != null)) haveSpriteRenderer = false;
        if (haveSpriteRenderer)
        {
            color = this.gameObject.GetComponent<SpriteRenderer>().color;

            while (color.a > 0)
            {
                color = this.gameObject.GetComponent<SpriteRenderer>().color;

                this.gameObject.GetComponent<SpriteRenderer>().color
                = new Color(color.r, color.g, color.b, color.a - 0.1f);

                yield return new WaitForSeconds(fadeSpeed);
            }
            this.gameObject.GetComponent<SpriteRenderer>().color
                = new Color(color.r, color.g, color.b, 0);

        }else
        {
            color = this.gameObject.GetComponent<Image>().color;

            while (color.a > 0)
            {
                color = this.gameObject.GetComponent<Image>().color;

                this.gameObject.GetComponent<Image>().color
                = new Color(color.r, color.g, color.b, color.a - 0.1f);

                yield return new WaitForSeconds(fadeSpeed);
            }
            this.gameObject.GetComponent<Image>().color
                = new Color(color.r, color.g, color.b, 0);
        }

        if (gameObject.name == "Logo")
        {
            SceneManager.LoadScene("PrologueScene");
        }

    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(fadeWaitTime);
        StartCoroutine("FadeOut");
    }

}
