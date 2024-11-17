using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    private int comboCounter=1;
    private float lastTimeAttack;
    private float comboWindow = .5f;
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       if (comboCounter > 3||lastTimeAttack >= Time.time+comboWindow)
        { comboCounter = 0; }
        Player.anim.SetInteger("comboCounter", comboCounter);//这行代码的意思是将一个整数值 comboCounter 设置到 Player 对象的动画控制器中。
        StateTimer = .1f;

    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttack = Time.time; 
        
    }

    public override void Update()
    {
        base.Update();
        if ((StateTimer<0))//保证冲刺时无法使用攻击
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (triggerCalled)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
