using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;
    [SerializeField] private BossSpecial bossSpecial;
    [SerializeField] private BossDeath bossDeath;
    [SerializeField] private bool test;
    [SerializeField] private BossState testState;

    void Start()
    {
        ChangeState(BossState.enter);   
        if(test)
            ChangeState(testState);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ChangeState(BossState state)
    {
        switch (state)
        {
            case BossState.enter:
                bossEnter.RunState();
                break;
            case BossState.fire:
                bossFire.RunState();
                print("fire");
                break;
            case BossState.special:
                bossSpecial.RunState();
                print("Special");
                break;
            case BossState.death:
                bossEnter.StopState();
                bossFire.StopState();
                bossSpecial.StopState();
                bossDeath.RunState();
                break;
            default:
                break;
        }
    }
}
public enum BossState
{
    enter,
    fire,
    special,
    death
}
