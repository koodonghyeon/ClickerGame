using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Text;
using System.IO;

public class cStageData : MonoBehaviour
{
    cGameSaveData saveData;
    public void FirstSetting()
    {
    }
    public void SyncTime()
    {
    }
    public void GoogleSaveData(XmlDocument doc, XmlNode rootNode)
    {
    }
    public void GoogleLoadData(XmlNode rootNode)
    {
    }
    public void SaveCurrntStageData(cGameSaveData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("StageData_{0}", (int)saveData.Index), SaveCurrntStageXml(saveData));
    }
    public void SaveMaxStageData(cGameSaveData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("StageData_{0}", (int)saveData.Index), SaveMaxStageXml(saveData));
    }
    public void SaveCurrntHPData(cGameSaveData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("StageData_{0}", (int)saveData.Index), SaveCurrntHPXml(saveData));
    }
    public void SaveMaxData(cGameSaveData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("StageData_{0}", (int)saveData.Index), SaveMaxXml(saveData));
    }
    public cGameSaveData LoadData(StageIndex Stageindex)
    {
        byte[] loadObject = (byte[])cDontDestroy.LoadBinaryFormat(string.Format("StageData_{0}", (int)Stageindex));
        if (loadObject == null)
            return null;
        return LoadXml(loadObject);
    }
    public void DeleteInvenData(StageIndex Stageindex)
    {
        cDontDestroy.DeleteBinaryFormat(string.Format("StageData_{0}", (int)Stageindex));
    }
    //현제스테이지 저장
    public void setCurrntStage(StageIndex Stageindex,int Index)
    {
        cGameSaveData saveData = LoadData(Stageindex);
        if (saveData == null)
        {
            saveData = cGameInfo.Instance.gameData.saveData;
            saveData.Index = Stageindex;
            saveData.currStageIndex = Index;       
            SaveCurrntStageData(saveData);
   
        }
        else
        {
            DeleteInvenData(Stageindex);

            saveData.Index = Stageindex;
            saveData.currStageIndex++;
            SaveCurrntStageData(saveData);
        }

    }

    public void setMaxStage(StageIndex Stageindex, int Index)
    {
        cGameSaveData saveData = LoadData(Stageindex);
        if (saveData == null)
        {
            saveData = cGameInfo.Instance.gameData.saveData;
            saveData.Index = Stageindex;
            saveData.maxClearStageIndex = Index;
            SaveMaxStageData(saveData);
        }
        else
        {
            DeleteInvenData(Stageindex);
        
            saveData.Index = Stageindex;
            saveData.maxClearStageIndex++;
            SaveMaxStageData(saveData);
        }

    }
    public void setCurrntHP(StageIndex Stageindex, int Index)
    {
        cGameSaveData saveData = LoadData(Stageindex);
        if (saveData == null)
        {
            saveData = cGameInfo.Instance.gameData.saveData;
            saveData.Index = Stageindex;


            saveData.SaveCurrnt = Index;

            SaveCurrntHPData(saveData);
        }
        else
        {
            DeleteInvenData(Stageindex);
     
            saveData.Index = Stageindex;
            saveData.SaveCurrnt = Index;

            SaveCurrntHPData(saveData);
        }

    }
    public void setMaxHP(StageIndex Stageindex, int Index)
    {
        cGameSaveData saveData = LoadData(Stageindex);
        if (saveData == null)
        {
            saveData = cGameInfo.Instance.gameData.saveData;
            saveData.Index = Stageindex;

            saveData.SaveMaxHP = Index;
            SaveMaxData(saveData);
        }
        else
        {
            DeleteInvenData(Stageindex);
            saveData.Index = Stageindex;
            saveData.SaveMaxHP = Index;
            SaveMaxData(saveData);
        }

    }
    byte[] SaveCurrntStageXml(cGameSaveData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("currntStageData", ((int)saveData.currStageIndex).ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    byte[] SaveMaxStageXml(cGameSaveData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("MaxStageData", ((int)saveData.maxClearStageIndex).ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    byte[] SaveCurrntHPXml(cGameSaveData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("HP", saveData.SaveCurrnt.ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    byte[] SaveMaxXml(cGameSaveData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("MaxHP", saveData.SaveMaxHP.ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    cGameSaveData LoadXml(byte[] loadData)
    {
    
        saveData = new cGameSaveData();
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
                case "currntStageData":
                    if (int.TryParse(attr.Value, out temp))
                    {
                        saveData.currStageIndex= temp;
                     
                    }
                    break;
                case "MaxStageData":
                    if (int.TryParse(attr.Value, out temp))
                    {
                  
                        saveData.maxClearStageIndex= temp;
                    }
                    break;
                case "HP":
                    if (int.TryParse(attr.Value, out temp))
                    {

                        saveData.SaveCurrnt = temp;
                    }
                    break;
                case "MaxHP":
                    if (int.TryParse(attr.Value, out temp))
                    {

                        saveData.SaveMaxHP =temp;
                    }
                    break;
            }
        }
        SaveMaxData(saveData);
        return saveData;
    }
}