using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDropItem : MonoBehaviour
{

    bool _end;
    bool _remove;
    Transform _transform;
    Vector3 _startPos;
    Vector3 _targetPos;
    Vector3 _centerPos;
    float _currTime;
    float _speed = 1;
    float _removeTime;
    public void Init(Vector3 startPos, Vector3 targetPos)
    {
        _transform = gameObject.transform;
        _startPos = startPos;
        _targetPos = targetPos;
        _centerPos = (_startPos + _targetPos) / 2;
        _centerPos.y = 15;
        _removeTime = Random.Range(0.5f, 3);
    }

    private void Update()
    {
        if (_remove)
            return;
        if (_end)
        {
            _currTime -= Time.deltaTime;
            if (_currTime <= 0)
            {
                int gold = cGameInfo.Instance.gameData.saveData.currStageIndex;
                cGameInfo.Instance.invenData.AddItem(ItemIndex.Gold, gold);
                cSoundManager.Instance.PlayActionSound("Gold");
                cDontDestroy.AddGoldLabelEffect(gold, _transform);
                Destroy(gameObject);
                _remove = true;

            }
            return;
        }
        _currTime += Time.deltaTime * _speed;
        _transform.position = cDontDestroy.Bezier3(_startPos, _centerPos, _targetPos, _currTime);
        _transform.Rotate(3, 1, 6);
        if (_currTime >= 1)
        {
            _transform.position = _targetPos;
            _transform.rotation = Quaternion.identity;
            _end = true;
            _currTime = _removeTime;
        }
    }

}
