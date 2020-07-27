using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemyShaking : MonoBehaviour
{
    Transform _transform;
    bool _shaking;
    int _shakingPower;
    float _shakingTime;
    bool _shakingApply;

    public void Init(GameObject owner)
    {
        _transform = owner.transform;
    }
    public void SetShaking(int power, float time)
    {
        _shakingPower = power;
        _shakingTime = time;
        _shaking = true;
    }

    public void Update()
    {
        if (_shaking == false)
            return;
        _shakingTime -= Time.deltaTime;
        if (_shakingTime <= 0)
        {
            _shaking = false;
            _transform.localPosition = Vector3.zero;
            return;
        }
        _shakingApply = !_shakingApply;
        if (_shakingApply == false)
        {
            int random = Random.Range(0, 8);
            float power = Random.Range(0, _shakingPower * 10);
            power /= 100;
            Vector3 pos = _transform.localPosition;
            switch (random)
            {
                case 0:
                    pos.x -= power;
                    pos.y -= power;
                    break;
                case 1:
                    pos.x -= power;
                    break;
                case 2:
                    pos.x -= power;
                    pos.y += power;
                    break;
                case 3:
                    pos.y -= power;
                    break;
                case 4:
                    pos.y += power;
                    break;
                case 5:
                    pos.x += power;
                    pos.y += power;
                    break;
                case 6:
                    pos.x += power;
                    break;
                case 7:
                    pos.x += power;
                    pos.y -= power;
                    break;
            }
            _transform.localPosition = pos;
        }
        else
        {
            _transform.localPosition = Vector3.zero;
        }
    }

}
