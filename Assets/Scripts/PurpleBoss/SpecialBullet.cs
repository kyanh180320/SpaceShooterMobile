using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject miniBullet;
    [SerializeField] private Transform[] spawnPoint;
    void Start()
    {
        rb.velocity = Vector2.down* speed;
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
    }
  
    IEnumerator Explode()
    {
        float randomExplodeTime = Random.Range(1f, 1.75f);
        yield return new WaitForSeconds(randomExplodeTime);
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(miniBullet, spawnPoint[i].position, spawnPoint[i].rotation);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
