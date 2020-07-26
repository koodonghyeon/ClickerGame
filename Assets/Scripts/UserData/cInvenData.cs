using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Text;
using System.IO;

public class cInvenData : MonoBehaviour
{
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
    public void SaveData(ItemSaveData saveData)
    {
        cDontDestroy.SaveBinaryFormat(string.Format("InvenItemData_{0}", (int)saveData.itemIndex), SaveXml(saveData));
    }
    public ItemSaveData LoadData(ItemIndex itemIndex)
    {
        byte[] loadObject = (byte[])cDontDestroy.LoadBinaryFormat(string.Format("InvenItemData_{0}", (int)itemIndex));
        if (loadObject == null)
            return null;
        return LoadXml(loadObject);
    }
    public void DeleteInvenData(ItemIndex itemIndex)
    {
        cDontDestroy.DeleteBinaryFormat(string.Format("InvenItemData_{0}", (int)itemIndex));
    }
    byte[] SaveXml(ItemSaveData saveData)
    {
        XmlDocument loadXmlDoc = new XmlDocument();
        XmlElement rootElemental = loadXmlDoc.CreateElement("ROOT");
        rootElemental.SetAttribute("ItemIndex", ((int)saveData.itemIndex).ToString());
        rootElemental.SetAttribute("Num", saveData.num.ToString());
        loadXmlDoc.AppendChild(rootElemental);
        return Encoding.Default.GetBytes(loadXmlDoc.OuterXml);
    }
    ItemSaveData LoadXml(byte[] loadData)
    {
        ItemSaveData saveData = new ItemSaveData();
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
                case "ItemIndex":
                    if (int.TryParse(attr.Value, out temp))
                    {
                        saveData.itemIndex = (ItemIndex)temp;
                    }
                    break;
                case "Num":
                    if (int.TryParse(attr.Value, out temp))
                    {
                        saveData.num = temp;
                    }
                    break;
            }
        }
        return saveData;
    }
    public void SaveItemList(List<ItemIndex> itemList)
    {
        cDontDestroy.SaveBinaryFormat("ItemList", itemList);
    }
    List<ItemIndex> LoadItemList()
    {
        object loadObject = cDontDestroy.LoadBinaryFormat("ItemList");
        if (loadObject == null)
        {
            List<ItemIndex> list = new List<ItemIndex>();
            SaveItemList(list);
            return list;
        }
        return (List<ItemIndex>)loadObject;
    }
    public void DeleteInven(ItemIndex itemIndex)
    {
        DeleteInvenData(itemIndex);
        List<ItemIndex> itemList = LoadItemList();
        itemList.Remove(itemIndex);
        SaveItemList(itemList);
    }
    public void AddItem(ItemIndex itemIndex, int num)
    {
        ItemSaveData saveData = LoadData(itemIndex);
        if (saveData == null)
        {
            saveData = new ItemSaveData();
            saveData.itemIndex = itemIndex;
            saveData.num = num;
            SaveData(saveData);
            List<ItemIndex> itemList = LoadItemList();
            itemList.Add(itemIndex);
            SaveItemList(itemList);
        }
        else
        {
            saveData.num += num;
            SaveData(saveData);
        }
        cGameScene.Instance.Refresh();
    }
    public void UseItem(ItemIndex itemIndex, int num)
    {
        ItemSaveData saveData = LoadData(itemIndex);
        if (saveData == null)
        {
            Debug.Log(string.Format("없는 아이템을 사용 합니다. {0}", itemIndex));
            return;
        }
        saveData.num -= num;
        if (saveData.num <= 0)
        {
            DeleteInven(itemIndex);
        }
        else
            SaveData(saveData);
        cGameScene.Instance.Refresh();
    }
    public bool IsHaveItem(ItemIndex itemIndex, int num)
    {
        ItemSaveData saveData = LoadData(itemIndex);
        if (saveData == null)
            return false;
        if (saveData.num < num)
            return false;
        return true;
    }
}
