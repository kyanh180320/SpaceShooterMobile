using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitsToDestroy = 3;
    public bool protection = false;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        protection = true;
    }
    private void DamageShield()
    {
        hitsToDestroy -= 1;
        if (hitsToDestroy <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void RepairShield()
    {
        hitsToDestroy = 3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (collision.CompareTag("Boss"))
            {
                hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamge(10000);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
