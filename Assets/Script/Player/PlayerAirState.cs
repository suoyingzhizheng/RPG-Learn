using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
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
       
        if (Player.IsGroundedDetected())
        {
            StateMachine.ChangeState(Player.IdleState);
        }
        if (xInput != 0)
        {
            Player.SetVelocity(Player.MoveSpeed * .8f * xInput,rb.velocity.y);
        }
        if(Player.IsWallDetected())
        {
            StateMachine.ChangeState(Player.SlideState);
        }
    }
}
