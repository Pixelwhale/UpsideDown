using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;					//for fading

public class SceneMgr : MonoBehaviour
{
    #region Fading
    public Image img;
    private IEnumerator FadeIn()
    {
        for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        // fade from opaque to transparent
        for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
    #endregion

    public void ReturnTitle()
    {
        StartCoroutine(FadeOut());
        SceneManager.LoadScene("title");
    }
    public void ReturnStageSelect()
    {
        StartCoroutine(FadeOut());
        SceneManager.LoadScene("StageSelect");
    }
    public void ReloadCurrent()
    {
        StartCoroutine(FadeOut());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Next()
    {
        StartCoroutine(FadeOut());
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current != SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(current + 1);
        else ReturnTitle();
    }
}
