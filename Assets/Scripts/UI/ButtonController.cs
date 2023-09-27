using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelInt(int levelIntdex)
    {
        FadeCanvas.fader.FaderLoadInt(levelIntdex);
    }
    public void RestartLevel()
    {
        FadeCanvas.fader.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);    
    }
    public void LoadLevelString(string levelName)
    {
        FadeCanvas.fader.FaderLoadString(levelName);
    }
    public void ReloadLevel()
    {
        FadeCanvas.fader.ReLoadLevel();
        SceneManager.LoadScene("Level1");
    }
}
