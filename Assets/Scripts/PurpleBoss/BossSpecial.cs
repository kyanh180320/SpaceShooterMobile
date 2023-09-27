using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecial : BossBaseState
{
    // Start is called before the first frame update
    private Vector2 targetPoint;
    [SerializeField] private float speed;
    [SerializeField] private GameObject specialBullet;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform shootingPoint;
    protected override void Start()
    {
        targetPoint = cameraMain.ViewportToWorldPoint(new Vector3(0.5f, 0.9f));
    }
    public override void RunState()
    {
        StartCoroutine(RunSpecialState());
    }
    IEnumerator RunSpecialState()
    {
        while (Vector2.Distance(transform.position, targetPoint) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Instantiate(specialBullet, shootingPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        bossController.ChangeState(BossState.fire);
    }
}
