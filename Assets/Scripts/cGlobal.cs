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