using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    float spriteHeight;
    [SerializeField] private float parralaxSpeed;
    void Start()
    {
        startPos= transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().size.y;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * parralaxSpeed);
        if (transform.position.y < startPos.y - spriteHeight)
        {
            transform.position = startPos;
        }
    }
}
