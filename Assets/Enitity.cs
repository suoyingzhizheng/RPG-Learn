using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enitity : MonoBehaviour
{

    [Header("Coliision info")]
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected float GroundCheckDistance;
    [SerializeField] protected Transform WallCheck;
    [SerializeField] protected float WallCheckDistance;
    [SerializeField] protected LayerMask WhatIsGround;
    public int FacingDir { get; private set; } = 1;
    protected bool FacingRight = true;
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    // Start is called before the first frame update
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
         
    }
    #region coliision
    public virtual bool IsGroundedDetected() => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, WhatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDir, WallCheckDistance, WhatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistance));
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance, WallCheck.position.y));
    }
    #endregion
    public virtual void Flip()
    {
        FacingDir = FacingDir * -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FliopController(float _x)
    {
        if (_x < 0 && FacingRight && !IsWallDetected())//为了改人物爬行的bug 加了条件 但会导致跳墙动作的bug 记得改
        {
            Flip();
        }
        else if (_x > 0 && !FacingRight && !IsWallDetected())
        {
            Flip();
        }
    }
    public void ZeroVelocity() =>rb.velocity = new Vector2(0, 0);   
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FliopController(_xVelocity);
    }

}
