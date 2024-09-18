using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float MoveSpeed = 12f;
    public Rigidbody2D rb {  get; private set; }
    #region Components
    public Animator anim { get; private set; }
    #endregion
    #region States
    public PlayerStateMachine StateMachine {  get; private set; }//允许外界读取数据 但不能改变数据
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    #endregion
    private void Awake()
    {//初始化状态机
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }
    public void SetVelocity(float _xVelocity,float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}
