using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]protected float health;
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
        if(health < 0)
        {
            DeathSequence();
        }
    }
    public virtual void HurtSequence()
    {

    }
    public virtual void DeathSequence()
    {

    }
}
