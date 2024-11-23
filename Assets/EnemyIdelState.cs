using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdelState : SkeletonGroundState
{
    public EnemyIdelState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBool, Enenmy_skeleton enemy) : base(_enemyBase, _stateMachine, _animBool, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        
    }
}
