using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxHealth;
    float health;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
}
