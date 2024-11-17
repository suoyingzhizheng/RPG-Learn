using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy ennemy;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBool)
    {
        this.ennemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBool;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        ennemy.anim.SetBool(animBoolName,true);
    }
    public virtual void Exit()
    {
        ennemy.anim.SetBool(animBoolName, false);
    }
}
