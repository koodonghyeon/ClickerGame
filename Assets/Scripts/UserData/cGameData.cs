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
    cHPData _saveHP = new cHPData();

    public cGameSaveData saveData
    {
        get { return _saveData; }
    }
    public cHPData saveHP
    {
        get { return _saveHP; }
    }
    public void FirstSetting()
    {
        _saveData = LoadData();
        cGameScene.Instance._StageText.text ="Stage " +_saveData.currStageIndex.ToString();
    }
    public void SyncTime()
    {
    }
    public void SaveData(cGameSaveData saveData)
    {
        cDontDestroy.SaveBinaryFormat("GameSaveData", SaveXml(saveData));
        _saveData = saveData;
    }
    public cGameSaveData LoadData()
    {
        byte[] loadObject = (byte[])cDontDestroy.LoadBinaryFormat("GameSaveData");
        if (loadObject == null)
        {
            cGameSaveData saveData = new cGameSaveData();
            saveData.currStageIndex = 1;
            saveData.maxClearStageIndex = 1;
         
            SaveData(saveData);
            return saveData;
        }
        return LoadXml(loadObject);
    }
    byte[] SaveXml(cGameSaveData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("CurrStageIndex", saveData.currStageIndex.ToString());
        rootElemental.SetAttribute("MaxClearStageIndex", saveData.maxClearStageIndex.ToString());

        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    cGameSaveData LoadXml(byte[] loadData)
    {
        cGameSaveData saveData = new cGameSaveData();
       MemoryStream m = new MemoryStream(loadData);
        XmlDocument loadXmlDoc = new XmlDocument();
        loadXmlDoc.Load(m);
        XmlNode rootNode = loadXmlDoc.SelectSingleNode("ROOT");
        for (int i = 0; i < rootNode.Attributes.Count; ++i)
        {
            int temp = 0;
            XmlAttribute attr = rootNode.Attributes[i];
            switch (attr.Name)
            {
                case "CurrStageIndex":
                    if (int.TryParse(attr.Value, out temp))
                    {
                        saveData.currStageIndex = temp;
                    }
                    break;
                case "MaxClearStageIndex":
                    if (int.TryParse(attr.Value, out temp))
                    {
                        saveData.maxClearStageIndex = temp;
                    }
                   break;
     
            }
        }
        return saveData;
    }

    public void VictoryStage()
    {

        if (_saveData.maxClearStageIndex < _saveData.currStageIndex)
            _saveData.maxClearStageIndex = _saveData.currStageIndex;
        ++_saveData.currStageIndex;
        SaveData(saveData);
    }


}
