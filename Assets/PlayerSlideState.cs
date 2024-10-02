using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideState : PlayerState
{
    public PlayerSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
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
        if(xInput!=0 && Player.FacingDir!=xInput)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
        if(Player.IsWallDetected())
        {
            StateMachine.ChangeState(Player.IdleState);
        }
        if(yInput<0)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        else
        {
              rb.velocity = new Vector2(0, rb.velocity.y*.7f);
        }
    }
}
