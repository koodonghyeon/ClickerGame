using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBattleMachine :MonoBehaviour
{

    BattleState _stateIndex;
    protected float _currTime;
    public virtual void Init(BattleState stateIndex)
    {
        _stateIndex = stateIndex;
    }
    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void UpdateFrame()
    {

    }
    public virtual void AfterUpdateFrame()
    {

    }

    public BattleState GetStateIndex()
    {
        return _stateIndex;
    }

    public virtual void OccurEventActionMessage(Event msg, params object[] paramList)
    {

    }

}
