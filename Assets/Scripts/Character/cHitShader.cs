using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void DelegateEndHide();
public class cHitShader : MonoBehaviour
{
    bool _activeRimPower;
    bool _activeHide;
    Transform _owner;
    float _power;
    List<Renderer> _rendererList = new List<Renderer>();

    DelegateEndHide _delegateHide;
    float _alpha;
    public void SetOwner(Transform owner)
    {
        _owner = owner;
        CollectRenderer(owner.gameObject);
        _activeRimPower = false;
    }
    public void SetRimColor(Color color)
    {
        _power = 1;
        RimColor(_owner, color);
        _activeRimPower = true;
    }
    public void Hide(DelegateEndHide delegateHide)
    {
        _delegateHide = delegateHide;
        _alpha = 1;
        _activeHide = true;
    }
    void Update()
    {
        ProcessRimPower();
        ProcessHide();
    }
    void ProcessRimPower()
    {
        if (_activeRimPower == false)
            return;
        if (_owner == null)
            return;
        _power -= Time.deltaTime * 2;
        if (_power <= 0)
        {
            _power = 0;
            _activeRimPower = false;
        }
        RimPower(_owner);
    }
    void ProcessHide()
    {
        if (_activeHide == false)
            return;
        if (_owner == null)
            return;
        _alpha -= Time.deltaTime * 2;
        if (_alpha <= 0)
        {
           _alpha = 0;
           _activeHide = false;
           _delegateHide();
        }
        Alpha(_owner);
    }
    void RimPower(Transform owner)
    { 
        for (int i = 0; i < _rendererList.Count; ++i)
        {
            _rendererList[i].material.SetFloat("_RimPower", _power);
        }
    }



    void RimColor(Transform owner, Color color)
    {
        for (int i = 0; i < _rendererList.Count; ++i)
        {
            _rendererList[i].material.SetColor("_RimColor", color);
        }

    }
    void Alpha(Transform owner)
    {
        for (int i = 0; i < _rendererList.Count; ++i)
        {
            _rendererList[i].material.SetFloat("_Alpha", _alpha);
        }
    }
    void CollectRenderer(GameObject owner)
    {
        Renderer renderer = owner.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            _rendererList.Add(renderer);
        }
        for (int i = 0; i < owner.transform.childCount; ++i)
        {
            CollectRenderer(owner.gameObject.transform.GetChild(i).gameObject);
        }
    }
  

}
