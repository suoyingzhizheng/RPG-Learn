using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float MoveSpeed = 12f;//�� C# �У�float �������ڱ�ʾ�����ȸ�������������ڸ�ֵʱ���� f ��׺���������Ὣ����Ĭ����Ϊ double ���͡�����ܵ��´���򾯸棬��Ϊ double ���͵�ֵ����ֱ�Ӹ��� float ���͵ı�����
    public float JumpForce;
    [Header("Dash info")]
    [SerializeField] private float DashCoolDown;
    [SerializeField] private float DashTimer;
    public float DashSpeed;
    public float DashDuration;
    public float DashDir { get; private set; }


    [Header("Coliision info")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;
   
    public Rigidbody2D rb {  get; private set; }
    public int FacingDir { get; private set; } = 1;
    private bool FacingRight = true;
    #region Components
    public Animator anim { get; private set; }
    #endregion
    #region States
    public PlayerStateMachine StateMachine {  get; private set; }//��������ȡ���� �����ܸı�����
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    public PlayerAirState AirState {  get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    #endregion
    private void Awake()
    {//��ʼ��״̬��
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        DashState = new PlayerDashState(this, StateMachine, "Dash");
    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }
    public float Timer;
    public float CoolDown = 5;
    private void Update()
    {
        StateMachine.currentState.Update();
        CheckDashInput();   
       
        
    }
    private void CheckDashInput()
    {
  
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashDir = Input.GetAxisRaw("Horizontal");
            if (DashDir == 0)
                DashDir = FacingDir;
            StateMachine.ChangeState(DashState);
        }
    }
    public void SetVelocity(float _xVelocity,float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FliopController(_xVelocity);
    }
    public bool IsGroundedDetected() =>Physics2D.Raycast(GroundCheck.position,Vector2.down,GroundCheckDistance,WhatIsGround);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position,new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistance));
        Gizmos.DrawLine(WallCheck.position,new Vector3(WallCheck.position.x+WallCheckDistance, WallCheck.position.y));
    }
    public void Flip()
    {
        FacingDir = FacingDir * -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }
    public void FliopController(float _x)
    {
        if(_x<0&&FacingRight)
        {
            Flip();
        }
        else if(_x>0&&!FacingRight)
        {
            Flip();
        }
    }
}
