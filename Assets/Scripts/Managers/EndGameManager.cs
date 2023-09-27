using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EndGameManager endGameManager;
    public PanelController panelController;
    public bool gameOver = false;
    private TextMeshProUGUI scoreTextComponent;
    private int score;
    private void Awake()
    {
        if (endGameManager == null)
        {
            endGameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartResolveGame()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResoleGame();
    }
    public void ResoleGame()
    {
        if (!gameOver)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        ScoreSet();
        panelController.ActiveWin();
    }
    public void LoseGame()
    {
        ScoreSet();
        panelController.ActiveLose();
    }
    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        scoreTextComponent = scoreTextComp;
    }
    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTextComponent.text = "Score: " + score.ToString();
    }
    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name,score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if (score > highScore)
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
        score = 0;
    }
}
