using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Text;
using System.IO;
public class cGameData
{
    cGameSaveData _saveData = new cGameSaveData();
    public cGameSaveData saveData
    {
        get { return _saveData; }
    }
    public void FirstSetting()
    {
    }
    public void SyncTime()
    {
    }
    public void VictoryStage()
    {
        if (_saveData.maxClearStageIndex < _saveData.currStageIndex)
            _saveData.maxClearStageIndex = _saveData.currStageIndex;
        ++_saveData.currStageIndex;
    }


}
