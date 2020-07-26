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
       _StageData = new cStageData();
    }
    bool _sycnSaveData;

    cGameData _gameData;
    cInvenData _invenData;
    cStageData _StageData;
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

    public cStageData StageData
    {
        get { return _StageData; }
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
