using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;
    private string animBoolName;//��Ӧ��������������,�� IdleState 
    protected Rigidbody2D rb;
    protected float xInput;
    protected float yInput;
    protected float StateTimer;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine,string _animBollName)
    {
        this.Player = _player;//��ֵ����ǰ���player�ֶ�
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
        Player.anim.SetFloat("yVelocity",rb.velocity.y);//����ҵĴ�ֱ�ٶȣ�rb.velocity.y�����ݸ� Animator���Ա��ڶ�����������ʹ�ø���ֵ�����Ʋ�ͬ�Ķ���״̬�򶯻�����
    }
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);//����ǰ�ĵĲ���ֵ��Ϊ0
    }
}
