using UnityEngine;
using System.Collections;

//상태들의 최상단부모
public class cStateMachine
{
    UnitState _stateIndex;
    protected cCharacter _owner;
    protected float _currTime;
    public virtual void Init(UnitState stateIndex, cCharacter owner)
    {
        _stateIndex = stateIndex;
        _owner = owner;
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
    public UnitState GetStateIndex()
    { 
        return _stateIndex;
    }
    public virtual void OccurEventActionMessage(Event msg, params object[] paramList)
    {

    }


}

