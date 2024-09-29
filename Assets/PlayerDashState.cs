using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = Player.DashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        Player.SetVelocity(0,rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        
        Player.SetVelocity(Player.DashSpeed*Player.DashDir,0);
        if (StateTimer < 0)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
