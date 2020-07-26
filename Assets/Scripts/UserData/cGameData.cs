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
    
        if (cGameInfo.Instance.gameData.saveData.maxClearStageIndex < cGameInfo.Instance.gameData.saveData.currStageIndex)
            cGameInfo.Instance.gameData.saveData.maxClearStageIndex = cGameInfo.Instance.gameData.saveData.currStageIndex;
        ++cGameInfo.Instance.gameData.saveData.currStageIndex;
    
        cGameInfo.Instance.StageData.setCurrntStage(StageIndex.currntStage, _saveData.currStageIndex);
        cGameInfo.Instance.StageData.setMaxStage(StageIndex.MaxClearStage, _saveData.maxClearStageIndex);
        cGameScene.Instance.StageRefresh();
    }


}
