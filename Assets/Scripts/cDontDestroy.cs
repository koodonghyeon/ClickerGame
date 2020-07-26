using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


//삭제되면 안되는 오브젝트를 관리하는 클래스
public static class cDontDestroy
{
    public static void SetGlobalManagerByAwake()
    {
        GameObject noRemoveManager = GameObject.Find("NoRemoveManager");
        if (null == noRemoveManager)
        {
            noRemoveManager = new GameObject("NoRemoveManager");
            MonoBehaviour.DontDestroyOnLoad(noRemoveManager);
        }
        if (null == noRemoveManager.GetComponent<MonoBehaviour>())
        {
            noRemoveManager.AddComponent<MonoBehaviour>();
        }
        if (null == noRemoveManager.GetComponent<cResourceManager>())
       {
            noRemoveManager.AddComponent<cResourceManager>();
        }
        if (null == noRemoveManager.GetComponent<cSoundManager>())
        {
            noRemoveManager.AddComponent<cSoundManager>();
        }
        if (null == noRemoveManager.GetComponent<cGameInfo>())
        {
            noRemoveManager.AddComponent<cGameInfo>();
        }
        //if (null == noRemoveManager.GetComponent<cScriptManager>())
        //{
        //    noRemoveManager.AddComponent<cScriptManager>();
        //}
    }
    static public void CreateInstanceToString<T>(ref T instance, string classMame)
    {
        Assembly assem = typeof(T).Assembly;
        instance = (T)assem.CreateInstance(classMame, false, BindingFlags.ExactBinding, null, null, null, null);
        if (instance == null)
            Debug.Log(string.Format("{0} Class not Found!", classMame));

    }
    static public Vector3 Bezier3(Vector3 p1, Vector3 p2, Vector3 p3, float mu)
    {
        float mum1, mum12, mu2;
        Vector3 p;
        mu2 = mu * mu;
        mum1 = 1 - mu;
        mum12 = mum1 * mum1;
        p.x = p1.x * mum12 + 2 * p2.x * mum1 * mu + p3.x * mu2;
        p.y = p1.y * mum12 + 2 * p2.y * mum1 * mu + p3.y * mu2;
        p.z = p1.z * mum12 + 2 * p2.z * mum1 * mu + p3.z * mu2;
        return (p);
    }


    static public void SaveBinaryFormat(string key, object data)
    {
        BinaryFormatter b = new BinaryFormatter();
        MemoryStream m = new MemoryStream();
        b.Serialize(m, data);
        PlayerPrefs.SetString(key, Convert.ToBase64String(m.GetBuffer()));
        return;
    }
    static public object LoadBinaryFormat(string key)
    {
        string data = PlayerPrefs.GetString(key);
        if (data == null || data == "")
        {
            return null;
        }
        BinaryFormatter b = new BinaryFormatter();
        MemoryStream m = new MemoryStream(Convert.FromBase64String(data));
        return b.Deserialize(m);
    }
    static public void DeleteBinaryFormat(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
    public static void AddGoldLabelEffect(int value, Transform ownerTransfrom)
    {
        GameObject assetObject = cResourceManager.Instance.ClonePrefab("GoldText");

        cDamageText effect = assetObject.GetComponent<cDamageText>();

        effect.damage = value;
        effect.transform.position = ownerTransfrom.position;
    }

}

