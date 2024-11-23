using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : SkeletonGroundState
{
    public EnemyMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBool, Enenmy_skeleton enemy) : base(_enemyBase, _stateMachine, _animBool, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(2*enemy.FacingDir*enemy.moveSpeed,rb.velocity.y);
        if(enemy.IsWallDetected()||!enemy.IsGroundedDetected())//地面检测有问题

        {
            enemy.Flip(); 
            stateMachine.ChangeState(enemy.idelState);
        }
         
    }
}
