using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/PowerUpSpawner", fileName ="Spawner")]
public class ScriptableObjectExample : ScriptableObject
{
    // Start is called before the first frame update
    public int spwnThreshold;
    public GameObject[] powerUp;
    public void SpawnerPowerUp(Vector3 spawnPos)
    {
        int randomChane = Random.Range(0, 100);
        if(randomChane > spwnThreshold)
        {
            int randomPowerUp = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[Random.Range(0, powerUp.Length)], spawnPos, Quaternion.identity);
        }
        
    }
}
