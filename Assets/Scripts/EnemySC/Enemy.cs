using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;
    [SerializeField] protected ScriptableObjectExample powerUpSpawner;

    [Header("Score"), SerializeField]
    protected int scoreValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamge(float dmg)
    {
        health -= dmg;
        HurtSequence();
        if (health < 0)
        {
            DeathSequence();
        }
    }
    public virtual void HurtSequence()
    {

    }
    public virtual void DeathSequence()
    {
        EndGameManager.endGameManager.UpdateScore(scoreValue);
        if (powerUpSpawner != null)
        {
            powerUpSpawner.SpawnerPowerUp(transform.position);
        }

    }
}
