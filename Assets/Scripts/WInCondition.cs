using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private bool hasBoss;
    public bool canSpawnBoss = false;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.endGameManager.gameOver == true)
        {
            EndGameManager.endGameManager.StartResolveGame();
            return;
        }
        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
         

            if (hasBoss == false)
            {
                EndGameManager.endGameManager.StartResolveGame();
            }
            else
            {
                canSpawnBoss = true;
                if (EndGameManager.endGameManager.gameOver == true)
                {
                    EndGameManager.endGameManager.StartResolveGame();
                    return;
                }
            }
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
            //gameObject.SetActive(false);
        }


    }
}

