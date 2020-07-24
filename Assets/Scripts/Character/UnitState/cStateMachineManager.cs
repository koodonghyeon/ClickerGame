using UnityEngine;
using System.Collections;

//상태를 관리하는 매니저
public class cStateMachineManager 
{


    cStateMachine _currState;

    cStateMachine _prevState;

    cStateMachine[] _states = new cStateMachine[(int)UnitState.Max];
    public void Init(cCharacter owner)
    {
        cStateMachine state = null;
        for (UnitState index = UnitState.Idle; index < UnitState.Max; ++index)
        {
            cDontDestroy.CreateInstanceToString<cStateMachine>(ref state, string.Format("c{0}State", index.ToString()));
            state.Init(index, owner);
            _states[(int)index] = state;
        }
    }
    public void Release()
    {
        _states = null;
    }
    public void UpdateFrame()
    {
        if (null == _currState)
            return;
        _currState.UpdateFrame();
    }

    public void AfterUpdateFrame()
    {
        if (null == _currState)
            return;
        _currState.AfterUpdateFrame();
    }
    public virtual void SetState(UnitState state)
    { 
        _prevState = _currState;
        _currState = _states[(int)state];
        if (null != _prevState)
        {
            _prevState.Exit();
        }
        _currState.Enter();
    }
    public bool IsCurrState(UnitState state)
    {
        if (null == _currState)
            return false;
        if (_currState.GetStateIndex() == state)
            return true;

        return false;
    }

    public bool IsPrevState(UnitState state)
    {
        if (null == _prevState)
            return false;
        if (_prevState.GetStateIndex() == state)
            return true;

        return false;
    }

    public void OccurEventActionMessage(Event msg, params object[] paramList)
    {
        if (_currState == null)
            return;
        _currState.OccurEventActionMessage(msg, paramList);

    }


}
