using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player Player;
    private string animBoolName;//对应布尔变量的名字,如 IdleState 
    protected Rigidbody2D rb;
    protected float xInput;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine,string _animBollName)
    {
        this.Player = _player;//赋值给当前类的player字段
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
        Player.anim.SetFloat("yvelocity",rb.velocity.y);//将玩家的垂直速度（rb.velocity.y）传递给 Animator，以便在动画控制器中使用该数值来控制不同的动画状态或动画过渡
    }
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);//将当前的的布尔值改为0
    }
}
