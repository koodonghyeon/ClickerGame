using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDamageState : cStateMachine
{
    public override void Enter()
    {
        _owner.SetAnimation("Damage");
      
    }
    public override void Exit()
    {
    }
    public override void UpdateFrame()
    {
        if (_owner.IsEndAnimation())
        {
            _owner.SetState(UnitState.Idle);
        }
    }
}
