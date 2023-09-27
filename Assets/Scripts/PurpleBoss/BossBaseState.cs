using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : MonoBehaviour
{
    // Start is called before the first frame update
    protected Camera cameraMain;
    protected Vector3 offset;
    protected float maxLeft, maxRight, maxDown, maxUp;
    protected BossController bossController;
    void Awake()
    {
        cameraMain = Camera.main;
        bossController = GetComponent<BossController>();
    }
    protected virtual void Start()
    {
        maxLeft = cameraMain.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        maxRight = cameraMain.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x;
        maxDown = cameraMain.ViewportToWorldPoint(new Vector3(0, 0.1f, 0)).y;
        maxUp = cameraMain.ViewportToWorldPoint(new Vector3(0, 0.9f, 0)).y;
    }
    public virtual void RunState()
    {

    }
    public virtual void StopState()
    {
        StopAllCoroutines();
    }

}
