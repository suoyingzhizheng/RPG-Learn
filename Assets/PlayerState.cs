using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player Player;
    private string animBoolName;
    protected Rigidbody2D rb;
    protected float xInput;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine,string _animBollName)
    {
        this.Player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBollName;
    }
    public virtual void Enter()
    {
        Player.anim.SetBool(animBoolName, true);
        rb = Player.rb;
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);
      
    }
}
