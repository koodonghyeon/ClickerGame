using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Event
{
    None,
    Max
}
public enum UnitState
{
    None,
    Idle,
    Move,
    Attack,
    Damage,
    Die,
    Max
}
public enum BattleState
{
    None,
    BattleReady,
    Battle,
    BattleResult,
    Max,
}
public enum ItemIndex
{
    None,
    Gold,
    Max,
}
public enum StageIndex
{
    None,
    currntStage,
    MaxClearStage,
    CurrntHP,
    MaxHP,
    Max,
}