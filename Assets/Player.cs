using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float MoveSpeed = 12f;
    public float JumpForce;
    public Rigidbody2D rb {  get; private set; }
    #region Components
    public Animator anim { get; private set; }
    #endregion
    #region States
    public PlayerStateMachine StateMachine {  get; private set; }//��������ȡ���� �����ܸı�����
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    public PlayerAirState AirState {  get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    #endregion
    private void Awake()
    {//��ʼ��״̬��
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
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
