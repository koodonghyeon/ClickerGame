using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cEnemy : MonoBehaviour
{
    public GameObject _model;
    Transform _Transform;
    int _currHp;
    int _maxHp;
    public Slider _hpBar;
    cEnemyShaking _Shake;

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
        _currHp = 100;
        _maxHp = 100;
        _Shake = gameObject.AddComponent<cEnemyShaking>();
        _Shake.Init(_model);
    }
    public void SetDamage(int damage)
    {
        if (_currHp <= 0)
        {
            return;
        }
        _currHp -= damage;
        _hpBar.value = (float)_currHp / (float)_maxHp;
        _Shake.SetShaking(3, 0.3f);
    }

    public Transform myTransform
    {
        get { return _Transform; }
    }

}
