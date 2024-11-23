using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenmy_skeleton : Enemy
{
    #region states
    public EnemyMoveState moveState {  get; private set; }
    public EnemyIdelState idelState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    #endregion  
    protected override void Awake()
    {
        base.Awake();
        idelState = new EnemyIdelState(this, stateMachine, "Idel",this);
        moveState = new EnemyMoveState(this, stateMachine,"Move",this);
        battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idelState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
