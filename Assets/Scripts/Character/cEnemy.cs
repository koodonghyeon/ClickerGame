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
    bool _Die;
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
       
        if (cGameInfo.Instance.gameData.saveData.currStageIndex % 5 == 0)
            {
                cGameInfo.Instance.gameData.saveData.SaveMaxHP *= 5;
                cGameInfo.Instance.StageData.setMaxHP(StageIndex.MaxHP, (int)cGameInfo.Instance.gameData.saveData.SaveMaxHP);
            }
            else
            {
                cGameInfo.Instance.gameData.saveData.SaveMaxHP += 20;
                cGameInfo.Instance.StageData.setMaxHP(StageIndex.MaxHP, (int)cGameInfo.Instance.gameData.saveData.SaveMaxHP);
            }

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
        cGameInfo.Instance.StageData.setCurrntHP(StageIndex.CurrntHP, (int)_currHp);
        if (_currHp <= 0)
        {
            cGameInfo.Instance.gameData.VictoryStage();
            PlayerPrefs.DeleteKey(string.Format("StageData_{0}",StageIndex.CurrntHP));
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
        cGameSaveData saveData = cGameInfo.Instance.StageData.LoadData(StageIndex.CurrntHP);
        int currntHP = _maxHp;
        if (saveData != null)
        {
            if (saveData.SaveCurrnt <= 0)
            {
                saveData.SaveCurrnt = _maxHp;
                currntHP = _maxHp;

            }
            else
                currntHP = saveData.SaveCurrnt;
        }
        _currHp = currntHP;
       cGameScene.Instance._hptext.text = string.Format("{0}", currntHP);
        
    }
    public void SetMaxHP()
    {
        cGameSaveData saveData = cGameInfo.Instance.StageData.LoadData(StageIndex.MaxHP);
        int MaxHP = 100;
        if (saveData != null)
        {
            MaxHP = saveData.SaveMaxHP;
            cGameInfo.Instance.gameData.saveData.SaveMaxHP = MaxHP;
        }

        _maxHp = MaxHP;
    }
    public Transform myTransform
    {
        get { return _Transform; }
    }

}
