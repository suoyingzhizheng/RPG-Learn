using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private Enenmy_skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBool, Enenmy_skeleton enemy) : base(_enemyBase, _stateMachine, _animBool)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;

    }


    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battelTime;
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if(stateTimer<0||Vector2.Distance(player.transform.position, enemy.transform.position)>15)
            {
                stateMachine.ChangeState(enemy.idelState);
            }
        }
            if (player.position.x > enemy.transform.position.x)
            {
                moveDir = 1;
            }
            else if (player.position.x < enemy.transform.position.x)
            {
                moveDir = -1;
               
            }
            enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    private bool CanAttack()
    {
        if(Time.time>=enemy.lastAttackTime+enemy.attackCoolDown)
        {
            enemy.lastAttackTime = Time.time;
            return true;
        }
        return false;

    }
}
