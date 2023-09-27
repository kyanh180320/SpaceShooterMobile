using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public static FadeCanvas fader;
    [SerializeField] private float changeValue;
    [SerializeField] private float waittime;
    [SerializeField] private bool fadeStarted = false;
    [SerializeField] private CanvasGroup canvasGroup;
    void Awake()
    {
        if (fader == null)
        {
            fader = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }
    }
    private void Start()
    {
        StartCoroutine(FadeIn());

    }
    public void FaderLoadString(string levelname)
    {
        StartCoroutine(FadeOutString(levelname));
    }
    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOutInt(levelIndex));
    }
    public void ReLoadLevel()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        fadeStarted = false;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waittime); 
        }
    }
    IEnumerator FadeOutString(string levelName)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waittime);
        }
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeOutInt(int levelIndex)
    {

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waittime);
        }
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeIn());
    }
    
}
