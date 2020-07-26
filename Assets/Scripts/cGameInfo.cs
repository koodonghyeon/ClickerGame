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
    }
    bool _sycnSaveData;

    cGameData _gameData = new cGameData();
    cInvenData _invenData = new cInvenData();
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

    public void FirstSetting()
    {
        _gameData.FirstSetting();
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
