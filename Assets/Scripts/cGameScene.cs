using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
     Camera _Main;
    public cEnemy enemy
    {
        get { return _enemy; }
        set { _enemy = value; }
    }
    cBattleManager _battleStateManager;
    public cBattleManager battleStateManager
    {
        get { return _battleStateManager; }
    }
    public Slider _HPBar;
    public Text _hptext;
    public int _PlayerDamage;
    public Text _StageText;
    public Text _GoldText;
    public void Awake()
    {
        instance = this;
        _character.Init();
        _character.SetState(UnitState.Idle);

        _battleStateManager = new cBattleManager();
        _battleStateManager.Init();
        _battleStateManager.SetState(BattleState.BattleReady);

        _Main = this.GetComponent<Camera>();
        _PlayerDamage = 5;
        Refresh();
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
        _enemy.SetDamage(_PlayerDamage);
       // Debug.Log(pos);
        Vector3 worldPos = _Main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0));
        GameObject effectObject = cResourceManager.Instance.ClonePrefab("Hit");
        effectObject.transform.position = worldPos;
    }
    public void AttackEvent(int attack)
    {
        if (_enemy == null)
            return;
        _enemy.SetDamage(attack);

    }
    public void Refresh()
    {
        ItemSaveData saveData = cGameInfo.Instance.invenData.LoadData(ItemIndex.Gold);
        int gold = 0;
        if (saveData != null)
            gold = saveData.num;
        _GoldText.text = string.Format(string.Format("Gold : {0}", gold));

    }

}
