using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

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
    }
    static public void CreateInstanceToString<T>(ref T instance, string classMame)
    {
        Assembly assem = typeof(T).Assembly;
        instance = (T)assem.CreateInstance(classMame, false, BindingFlags.ExactBinding, null, null, null, null);
        if (instance == null)
            Debug.Log(string.Format("{0} Class not Found!", classMame));

    }
}
