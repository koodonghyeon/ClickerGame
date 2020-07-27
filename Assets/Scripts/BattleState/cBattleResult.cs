using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBattleResult : cBattleMachine
{
    public override void Enter()
    {
      
        Destroy(cGameScene.Instance._enemy.gameObject);
       cGameScene.Instance.battleStateManager.SetState(BattleState.BattleReady);
    }
    public override void Exit()
    {
    }
    public override void UpdateFrame()
    {
    }
}
