using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : BossBaseState
{
    // Start is called before the first frame update
    public override void RunState()
    {
        EndGameManager.endGameManager.StartResolveGame();
        gameObject.SetActive(false);
    }
}
