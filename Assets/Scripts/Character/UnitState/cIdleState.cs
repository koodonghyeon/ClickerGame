using System.Collections;
using UnityEngine;

public class cIdleState : cStateMachine
{
   public override void Enter()
    {
        _owner.SetAnimation("Idle");
        _currTime = 0;
    }
    public override void Exit()
    {
    }
    public override void UpdateFrame()
    {
        _currTime += Time.deltaTime;
        if (_currTime < _owner.attackSpeed)
            return;
            
        _owner.SetState(UnitState.Attack);
        

    }
}
