using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cEnemy : MonoBehaviour
{
    public GameObject _model;
    Transform _Transform;
    float _currHp=100;

    float _maxHp=100;
    cEnemyShaking _Shake;
    cHitShader _Shader;
    Material _material;
   public GameObject _DamageText;
    public float currHp
    {
        get { return _currHp; }
        set { _currHp = value; }
    }
    public float maxHp
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
        if (cGameInfo.Instance.gameData.saveData.currStageIndex % 5 == 0)
        {
            cGameInfo.Instance.gameData.saveData.SaveMaxHP *= 5;
          
        }
        else
        {
            cGameInfo.Instance.gameData.saveData.SaveMaxHP += 20;
        }
        _maxHp = cGameInfo.Instance.gameData.saveData.SaveMaxHP;
        _currHp = _maxHp;
        cGameScene.Instance._hptext.text = _currHp.ToString();
        cGameScene.Instance._HPBar.value = 1;
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
        if (_currHp <= 0)
        {
            _currHp = 0;
            _Die = true;
            cSoundManager.Instance.PlayActionSound("Dead");
            _Shader.Hide(_hide);
            cGameInfo.Instance.gameData.VictoryStage();

        }
    }
    public void EndHide()
    {
        cGameScene.Instance.battleStateManager.SetState(BattleState.BattleResult);
    }
    public Transform myTransform
    {
        get { return _Transform; }
    }

}
