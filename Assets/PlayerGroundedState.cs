using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
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
        if(!Player.IsGroundedDetected())
        {
            StateMachine.ChangeState(Player.AirState);
        }

        if(Input.GetKeyDown(KeyCode.Space) && Player.IsGroundedDetected())
        {
            StateMachine.ChangeState(Player.JumpState);
        }
    }
}
