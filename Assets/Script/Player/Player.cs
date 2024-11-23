using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enitity
{
    [Header("Attack info")]
    public Vector2[] attackMovement;
    
    [Header("Move info")]
    public float MoveSpeed = 12f;//在 C# 中，float 类型用于表示单精度浮点数。如果你在赋值时不加 f 后缀，编译器会将数字默认视为 double 类型。这可能导致错误或警告，因为 double 类型的值不能直接赋给 float 类型的变量。
    public float JumpForce;
    [Header("Dash info")]
    [SerializeField] private float DashCoolDown;
    [SerializeField] private float DashTimer;
    private float DashUsageTimer;
    public float DashSpeed;
    public float DashDuration;
    public float DashDir { get; private set; }


   
    
   
    #region States
    public PlayerStateMachine StateMachine {  get; private set; }//允许外界读取数据 但不能改变数据
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    public PlayerAirState AirState {  get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerSlideState SlideState { get; private set; }    
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    #endregion
    protected override void Awake()
    {//初始化状态机B
        base.Awake();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine,"Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        DashState = new PlayerDashState(this, StateMachine, "Dash");
        SlideState = new PlayerSlideState(this, StateMachine, "Slide");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, "Jump");
        AttackState = new PlayerAttackState(this, StateMachine, "Attack");
    }
    protected override void Start()
    {
       base.Start();
        StateMachine.Initialize(IdleState);
    }
    public float Timer;
    public float CoolDown = 5;
    protected override void Update()
    {
        base .Update();
        StateMachine.currentState.Update();
        CheckDashInput();
        
       
        
    }
    public void AnimiationTrigger() => StateMachine.currentState.AnimatorFinishTrigger();
    private void CheckDashInput()
    {
        if(IsWallDetected())
        { return; }

       DashUsageTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift)&&DashUsageTimer<0)
        {
            DashUsageTimer = DashCoolDown;
            DashDir = Input.GetAxisRaw("Horizontal");
            if (DashDir == 0)
                DashDir = FacingDir;
            StateMachine.ChangeState(DashState);
        }
    }
    
   
    
}
