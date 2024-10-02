using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;
    private string animBoolName;//对应布尔变量的名字,如 IdleState 
    protected Rigidbody2D rb;
    protected float xInput;
    protected float yInput;
    protected float StateTimer;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine,string _animBollName)
    {
        this.Player = _player;//赋值给当前类的player字段
        this.StateMachine = _stateMachine;
        this.animBoolName = _animBollName;
    }
    public virtual void Enter()
    {
        Player.anim.SetBool(animBoolName, true);
        rb = Player.rb;
    }
    public virtual void Update()
    {
        StateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Player.SetVelocity(xInput * Player.MoveSpeed, rb.velocity.y);
        Player.anim.SetFloat("yVelocity",rb.velocity.y);//将玩家的垂直速度（rb.velocity.y）传递给 Animator，以便在动画控制器中使用该数值来控制不同的动画状态或动画过渡
    }
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);//将当前的的布尔值改为0
    }
}
