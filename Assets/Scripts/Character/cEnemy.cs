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
        _currHp = 100;
        _maxHp = 100;
        //int enemyRandomValue = Random.Range(1, 10);

        //_material.mainTexture = (Texture2D)Resources.Load(string.Format("Texture/Enemy/Enemy{0}", 1), typeof(Texture2D));
    }
    public void SetDamage(int damage)
    {
        _currHp -= damage;
        if (_currHp <= 0)
        {
            _currHp = 0;
            cGameScene.Instance.battleStateManager.SetState(BattleState.BattleResult);
           
        }
       
        _Shake.SetShaking(2, 0.2f);
        _Shader.SetRimColor(Color.red);
        cGameScene.Instance._HPBar.value = (float)_currHp / (float)_maxHp;
    }

    public Transform myTransform
    {
        get { return _Transform; }
    }

}
