using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    // Start is called before the first frame update
    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;
    Rigidbody2D rb2d;
    float speed;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
        rb2d.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void HurtSequence()
    {
        base.HurtSequence();
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}