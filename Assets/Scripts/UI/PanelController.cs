using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject loseScreen, winScreen;
    [SerializeField] CanvasGroup cGroup;
    private void Start()
    {
        EndGameManager.endGameManager.RegisterPanelController(this);
    }
    public void ActiveWin()
    {
        cGroup.alpha= 1;
        winScreen.SetActive(true);
    }
    public void ActiveLose()
    {
        cGroup.alpha = 1;
        loseScreen.SetActive(true);
    }
}
