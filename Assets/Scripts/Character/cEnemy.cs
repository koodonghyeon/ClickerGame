using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cEnemy : MonoBehaviour
{
    public GameObject _model;
    Transform _Transform;
    int _currHp;
    int _maxHp;
    cEnemyShaking _Shake;
    cHitShader _Shader;
    Material _material;
   public GameObject _DamageText;
    public int currHp
    {
        get { return _currHp; }
        set { _currHp = value; }
    }
    public int maxHp
    {
        get { return _maxHp; }
        set {_maxHp = value; }
    }
    DelegateEndHide _hide;
    bool _Die=false;
    private void Awake()
    {
        _Transform = transform;
        
        _Shake = gameObject.AddComponent<cEnemyShaking>();
        _Shake.Init(_model);
        _Shader = gameObject.AddComponent<cHitShader>();
        _Shader.SetOwner(_model.transform);
        _material = _model.GetComponent<Renderer>().material;

    }
    public void Init()
    {
        SetMaxHP();
        _maxHp = cGameInfo.Instance.gameData.saveHP.SaveMaxHP;

        SetCurrntHP();

        if (_maxHp == _currHp)
        cGameScene.Instance._HPBar.value = 1;
       else
        cGameScene.Instance._HPBar.value = (float)_currHp / (float)_maxHp;
        _hide = new DelegateEndHide(EndHide);
    }
    public void SetDamage(int damage)
    {
        if (_Die)
            return;
        _currHp -= damage;
 
       
        _Shake.SetShaking(2, 0.2f);
        _Shader.SetRimColor(Color.red);
        cSoundManager.Instance.PlayActionSound("Peok");
        cGameScene.Instance._HPBar.value = (float)_currHp / (float)_maxHp;
        cGameScene.Instance._hptext.text = _currHp.ToString();
        GameObject DamText = Instantiate(_DamageText);
        DamText.GetComponent<cDamageText>().damage = damage;
        cGameInfo.Instance.HPData.setCurrntHP(HPIndex.CurrntHP, (int)_currHp);
        if (_currHp <= 0)
        {
            cGameInfo.Instance.gameData.VictoryStage();
            PlayerPrefs.DeleteKey(string.Format("StageData_{0}",HPIndex.CurrntHP));
            _currHp = 0;
            _Die = true;
            cSoundManager.Instance.PlayActionSound("Dead");
            _Shader.Hide(_hide);
        
            cDropManager.Instance.DropGold(this);
          
        }
    }
    public void EndHide()
    {
        cGameScene.Instance.battleStateManager.SetState(BattleState.BattleResult);
    }
    public void SetCurrntHP()
    {
        cHPData saveData = cGameInfo.Instance.HPData.LoadData(HPIndex.CurrntHP);
        int currntHP = _maxHp;
        if (saveData != null)
        {
            if (saveData.SaveCurrnt <= 0)
            {
                saveData.SaveCurrnt = _maxHp;
                _maxHp= currntHP;

            }
            else
                currntHP = saveData.SaveCurrnt;
        }
        _currHp = currntHP;
       cGameScene.Instance._hptext.text = string.Format("{0}", currntHP);
        
    }
    public void SetMaxHP()
    {
        cHPData saveData = cGameInfo.Instance.HPData.LoadData(HPIndex.MaxHP);
        int MaxHP = 100;
        if (saveData != null)
        {
            MaxHP = saveData.SaveMaxHP;
            if (cGameInfo.Instance.gameData.saveData.currStageIndex != 1)
            {
                if (cGameInfo.Instance.gameData.saveData.currStageIndex % 5 == 0)
                {
                    MaxHP *= 5;
                }
                else
                {
                    MaxHP += 20;
                }
            }
            cGameInfo.Instance.gameData.saveHP.SaveMaxHP = MaxHP;
        }
        cGameInfo.Instance.HPData.setMaxHP(HPIndex.MaxHP, (int)cGameInfo.Instance.gameData.saveHP.SaveMaxHP);
        _maxHp = MaxHP;
    }
    public Transform myTransform
    {
        get { return _Transform; }
    }

}
