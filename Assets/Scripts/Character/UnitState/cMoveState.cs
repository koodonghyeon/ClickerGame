using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이동상태
public class cMoveState : cStateMachine
{
    public override void Enter()
    {
        _owner.SetAnimation("Move");
        _currTime = 0;
    }
    public override void Exit()
    {
    }
    public override void UpdateFrame()
    {
        //_currTime += Time.deltaTime;
        //if (_currTime >= 1)
        //{
        //    _owner.SetState(UnitState.Idle);
        //}
    }
}
