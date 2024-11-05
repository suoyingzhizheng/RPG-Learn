using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private int comboCounter=0;
    private float lastTimeAttack;
    private float comboWindow = 2;
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter >3) { comboCounter = 0; }
        Debug.Log(comboCounter);
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttack = Time.time; 
        Player.anim.SetInteger("comboCounter",comboCounter);//���д������˼�ǽ�һ������ֵ comboCounter ���õ� Player ����Ķ����������С�

    }

    public override void Update()
    {
        base.Update();
        if(triggerCalled)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
