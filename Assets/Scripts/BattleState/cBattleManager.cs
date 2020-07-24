using System.Collections;
using UnityEngine;

public class cBattleManager
{

    cBattleMachine _currState;
    cBattleMachine _prevState;
    cBattleMachine[] _states = new cBattleMachine[(int)BattleState.Max];
    public void Init()
    {
        cBattleMachine state = null;
        for (BattleState index = BattleState.None + 1; index < BattleState.Max; ++index)
        {

            cDontDestroy.CreateInstanceToString<cBattleMachine>(ref state, string.Format("c{0}", index.ToString()));

            state.Init(index);

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

    public virtual void SetState(BattleState state)
    {
        _prevState = _currState;
        _currState = _states[(int)state];

        if (null != _prevState)
        {
            _prevState.Exit();
        }
        _currState.Enter();
    }
    public bool IsCurrState(BattleState state)
    {
        if (null == _currState)
            return false;
        if (_currState.GetStateIndex() == state)
            return true;
        return false;
    }

    public bool IsPrevState(BattleState state)
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
