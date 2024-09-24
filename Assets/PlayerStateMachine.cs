using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState {  get; private set; } 
    public void Initialize(PlayerState _startState)
    {

        currentState = _startState;
        currentState.Enter();
    }
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit(); //当前状态退出
        currentState = _newState;//建立新状态
        currentState.Enter();//进入新状态
    }
     
}
