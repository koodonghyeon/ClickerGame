using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDropManager : MonoBehaviour
{
    private static cDropManager instance;
    public static cDropManager Instance
    {
        get { return instance; }
    }



    public Transform _parentPosTransform;

    List<Transform> _goldPosList = new List<Transform>();
    private void Awake()
    {
        instance = this;
    }

    public void DropGold(cEnemy deadEnemy)
    {
        _goldPosList.Clear();

        for (int i = 0; i < _parentPosTransform.childCount; ++i)
        {
            _goldPosList.Add(_parentPosTransform.GetChild(i).transform);
        }
        int randomValue = Random.Range(5, 18);
        for (int i = 0; i < randomValue; ++i)
        {
            GameObject coinObject = cResourceManager.Instance.ClonePrefab("coin");
            cDropItem dropItem = coinObject.AddComponent<cDropItem>();
            int randomPos = Random.Range(0, _goldPosList.Count);
            dropItem.Init(deadEnemy.myTransform.position, _goldPosList[randomPos].position);
            _goldPosList.RemoveAt(randomPos);
        }

    }


}
