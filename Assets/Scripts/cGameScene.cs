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
    public int _PlayerDamage=10;
   // public int _BasicDamage=10;
    public Text _StageText;
    public Text _GoldText;
    public void Awake()
    {
        instance = this;
        _character.SetState(UnitState.Idle);

        _battleStateManager = new cBattleManager();
        _battleStateManager.Init();
        _battleStateManager.SetState(BattleState.BattleReady);
       //PlayerPrefs.DeleteAll();
        _Main = this.GetComponent<Camera>();
        cGameInfo.Instance.FirstSetting();
       // _PlayerDamage = cGameInfo.Instance.Unit._saveData.TabDamage;
        _character.Init();
  
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
    public void GoldRefresh()
    {
        ItemSaveData saveData = cGameInfo.Instance.invenData.LoadData(ItemIndex.Gold);
        int gold = 0;
        if (saveData != null)
            gold = saveData.num;
        _GoldText.text = string.Format(string.Format("Gold : {0}", gold));

    }

}
