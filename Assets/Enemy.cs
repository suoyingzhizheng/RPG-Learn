using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :Enitity
{
    [SerializeField]protected LayerMask whatIsPlayer;
    public EnemyStateMachine stateMachine { get; private set; }
    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battelTime;
    [Header("Attack info")]
    public float attackDistance;
    public float attackCoolDown;
    public float lastAttackTime;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();

    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AniamtionFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected()=>Physics2D.Raycast(WallCheck.position,Vector2.right *FacingDir,50,whatIsPlayer);
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * FacingDir, transform.position.y));
    }
}
