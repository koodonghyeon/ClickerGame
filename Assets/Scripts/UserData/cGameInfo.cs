using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGameInfo : MonoBehaviour
{
    private static cGameInfo instance;
    public static cGameInfo Instance
    {
        get { return instance; }
    }
    private  void Awake()
    {
        instance = this;
       _gameData = new cGameData();
       _invenData = new cInvenData();
       _HPData = new cHP();
       // _Unit = new cUnit();
    }
    bool _sycnSaveData;

    cGameData _gameData;
    cInvenData _invenData;
    cHP _HPData;
    //cUnit _Unit;
    //public cUnit Unit
    //{
    //    get { return _Unit; }
    //}
    public bool syncSaveData
    {
        get { return _sycnSaveData; }
    }
    public cGameData gameData
    {
        get { return _gameData; }
    }
    public cInvenData invenData
    {
        get { return _invenData; }
    }

    public cHP HPData
    {
        get { return _HPData; }
    }
    public void FirstSetting()
    {
        _gameData.FirstSetting();
        //_Unit.FirstSetting();
    }
    public void SyncTime()
    {
        _gameData.SyncTime();
        _sycnSaveData = true;
    }
    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        _sycnSaveData = false;
    }


 
}
