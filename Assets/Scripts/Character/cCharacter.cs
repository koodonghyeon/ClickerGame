using UnityEngine;

using System.Collections;



public class cCharacter : MonoBehaviour
{
    Transform _myTransform;
    cStateMachineManager _stateMachineManager;
    Animator _animation;
    int _attack=10;
    int _BasicAttack = 10;
    public float attackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    float _BasicattackSpeed = 1;
    float _attackSpeed =1;
    public  void Awake()
    {

        _stateMachineManager = new cStateMachineManager();
        _stateMachineManager.Init(this);
        _myTransform = transform;
        _animation = GetComponent<Animator>();
      
    }
    public void Init()
    {
        //_attack = cGameInfo.Instance.Unit._saveData.UnitAttack;
        //_attackSpeed = cGameInfo.Instance.Unit._saveData.UnitSpeed;
       // _BasicattackSpeed -= _attackSpeed;
    }
   public void UpdateFrame()
    {
        if (null != _stateMachineManager)
        {
            _stateMachineManager.UpdateFrame();
        }
    }
    public void AfterUpdateFrame()
    {
        if (null != _stateMachineManager)
        {
            _stateMachineManager.AfterUpdateFrame();
        }
    }
    public void SetState(UnitState state)
    {
        if (null == _stateMachineManager)
            return;
        _stateMachineManager.SetState(state);

    }



    public bool IsCurrState(UnitState state)
    {
        if (null == _stateMachineManager)
            return false;
        return _stateMachineManager.IsCurrState(state);
    }
    public bool IsPrevState(UnitState state)
    {
        if (null == _stateMachineManager)
            return false;
        return _stateMachineManager.IsPrevState(state);
    }
    public Vector3 pos
    {
        get { return _myTransform.position; }
        set { _myTransform.position = value; }
    }
    public void OccurEventActionMessage(Event msg, params object[] paramList)
    {
        if (_stateMachineManager != null)
        {
            _stateMachineManager.OccurEventActionMessage(msg, paramList);
        }
    }
    public void SetAnimation(string aniName)
    {
        _animation.SetTrigger(aniName);
    }
    public bool IsEndAnimation()
    {
        if (_animation.GetCurrentAnimatorStateInfo(0).normalizedTime >=1f)
            return true;
        else
            return false;
 
    }
    public Transform myTransform
    {
        get { return _myTransform; }

    }
    public void AttackEvent()
    {
        cGameScene.Instance.AttackEvent(_attack+ _BasicAttack);
    }


}
