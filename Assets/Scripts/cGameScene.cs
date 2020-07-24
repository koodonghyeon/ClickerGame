using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGameScene : MonoBehaviour
{
    private static cGameScene instance;
    public static cGameScene Instance
    {
        get
        {
            return instance;
        }
    }
   public cCharacter _character;
    public cEnemy _enemy;
    public void Awake()
    {
        instance = this;
        _character.Init();
        _character.SetState(UnitState.Idle);

    }
    public void Update()
    {
        if (_character)
        {
            _character.UpdateFrame();
        }
    }
    public void LateUpdate()
    {
        if (_character)
        {
            _character.AfterUpdateFrame();
        }
    }
    public void TouchScreen(Vector3 pos)
    {
        if (_enemy == null)
            return;
        _enemy.SetDamage(10);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0));
        GameObject effectObject = cResourceManager.Instance.ClonePrefab("Hit");
        effectObject.transform.position = worldPos;
    }
    public void AttackEvent(int attack)
    {
        if (_enemy == null)
            return;
        _enemy.SetDamage(attack);

    }
}
