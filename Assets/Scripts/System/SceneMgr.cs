using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;					//for fading

public class SceneMgr : MonoBehaviour
{
    private Image img;                       //fade用
    private float fadingSpeed = 1.0f;       //fadingの速さ

    void Start()
    {
        img = transform.Find("UI").Find("Canvas").Find("FadeImage").GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    #region Fading
    private IEnumerator FadeIn()
    {
        for (float i = 1; i >= 0; i -= fadingSpeed * Time.unscaledDeltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        // fade from opaque to transparent
        for (float i = 0; i <= 1; i += fadingSpeed * Time.unscaledDeltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
    #endregion

    public IEnumerator ReturnTitle()
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1 / fadingSpeed);
        SceneManager.LoadScene("Title");
    }
    public IEnumerator ReturnStageSelect()
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1 / fadingSpeed);
        SceneManager.LoadScene("StageSelect");
    }
    public IEnumerator ReloadCurrent()
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1 / fadingSpeed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator Next()
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1 / fadingSpeed);
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current != SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(current + 1);
        else ReturnTitle();
    }
}
