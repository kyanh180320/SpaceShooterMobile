using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    // Start is called before the first frame update

    private float shootTimer = 0;
    [SerializeField] private float shootInterval;
    [SerializeField] private float speed;
    [SerializeField] private Transform leftCanon, rightCanon;
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCanon.position, transform.rotation);
            Instantiate(bulletPrefab, rightCanon.position, transform.rotation);
            shootTimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        anim.SetTrigger("Damage");
    }
    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}







}
