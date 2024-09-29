using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity =new Vector2(rb.velocity.x, Player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        if (rb.velocity.y < 0 )
        {
            StateMachine.ChangeState(Player.AirState);
        }

    }
}
