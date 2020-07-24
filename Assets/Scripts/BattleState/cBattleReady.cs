using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBattleReady : cBattleMachine
{
    public override void Enter()
    {
        int enemyRandomValue = Random.Range(1, 10);
        GameObject enemyObject = cResourceManager.Instance.ClonePrefab("Enemy"+ enemyRandomValue);
        cGameScene.Instance.enemy = enemyObject.GetComponent<cEnemy>();
        cGameScene.Instance.enemy.Init();
        cGameScene.Instance.battleStateManager.SetState(BattleState.Battle);
    }
    public override void Exit()
    {
    }
    public override void UpdateFrame()
    {
    }
}
