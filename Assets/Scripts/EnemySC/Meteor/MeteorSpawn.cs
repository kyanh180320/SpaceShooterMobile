using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] meteor;
    [SerializeField] private float spawnTime;
    private float timer;
    float maxLeft,maxRight;
    private Camera cameraMain;
    private float yPos;

    void Start()
    {
        cameraMain = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Vector2 randomPos = new Vector2(Random.Range(maxLeft, maxRight), yPos);
            int i = Random.Range(0, meteor.Length);
            GameObject obj = Instantiate(meteor[i], randomPos, Quaternion.Euler(0,0,Random.Range(0, 360)));
            float size = Random.Range(0.8f, 1.2f);
            obj.transform.localScale = Vector3.one * size;
            timer = 0;
        }
    }
    IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.2f);//waiting time to camera load data correct
        maxLeft = cameraMain.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        maxRight = cameraMain.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x;
        yPos = cameraMain.ViewportToWorldPoint(new Vector3(0,1.1f,0)).y;
       
    }
  
}
