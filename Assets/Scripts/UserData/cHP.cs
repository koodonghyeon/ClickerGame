using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Text;
using System.IO;

public class cHP : MonoBehaviour
{
    cHPData saveData;
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
    public void SaveCurrntHPData(cHPData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("HPData_{0}", (int)saveData.Index), SaveCurrntHPXml(saveData));
    }
    public void SaveMaxData(cHPData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("HPData_{0}", (int)saveData.Index), SaveMaxXml(saveData));
    }
    public cHPData LoadData(HPIndex Stageindex)
    {
        byte[] loadObject = (byte[])cDontDestroy.LoadBinaryFormat(string.Format("HPData_{0}", (int)Stageindex));
        if (loadObject == null)
            return null;
        return LoadXml(loadObject);
    }
    public void DeleteInvenData(HPIndex Stageindex)
    {
        cDontDestroy.DeleteBinaryFormat(string.Format("HPData_{0}", (int)Stageindex));
    }
    public void setCurrntHP(HPIndex Stageindex, int Index)
    {
        cHPData saveData = LoadData(Stageindex);
        if (saveData == null)
        {
            saveData = cGameInfo.Instance.gameData.saveHP;
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
    public void setMaxHP(HPIndex Stageindex, int Index)
    {
        cHPData saveData = LoadData(Stageindex);
        if (saveData == null)
        {
            saveData = cGameInfo.Instance.gameData.saveHP;
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
  
    byte[] SaveCurrntHPXml(cHPData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("HP", saveData.SaveCurrnt.ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    byte[] SaveMaxXml(cHPData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("MaxHP", saveData.SaveMaxHP.ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    cHPData LoadXml(byte[] loadData)
    {
    
        saveData = new cHPData();
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
                case "HP":
                    if (int.TryParse(attr.Value, out temp))
                    {

                        saveData.SaveCurrnt = temp;
                    }
                    break;
                case "MaxHP":
                    if (int.TryParse(attr.Value, out temp))
                    {

                        saveData.SaveMaxHP = temp;
                    }
                    break;
            }
        }
        return saveData;
    }
}