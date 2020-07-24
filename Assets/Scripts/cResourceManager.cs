using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//리소스 매니저
public class cResourceManager : MonoBehaviour
{
    private static cResourceManager instance;
    public static cResourceManager Instance
    {
        get
        {
            return instance;

        }
    }
    private Dictionary<string, GameObject> _prefab = new Dictionary<string, GameObject>();

    private Dictionary<string, GameObject> _commonPrefab = new Dictionary<string, GameObject>();



    public void Awake()
    {
        instance = this;
        LoadAllPrefab();
    }


    //전체프리펩 읽어오기
    public void LoadAllPrefab()

    {

        object[] t0 = Resources.LoadAll("Prefabs");

        for (int i = 0; i < t0.Length; i++)

        {

            GameObject t1 = (GameObject)(t0[i]);

            if (_commonPrefab.ContainsKey(t1.name))
                continue;

            _commonPrefab[t1.name] = t1;

        }

    }


    //프리펩 폴더 읽어오기
    public void LoadPrefabFloder(string subfolder)

    {

        object[] t0 = Resources.LoadAll(subfolder);

        for (int i = 0; i < t0.Length; i++)

        {

            GameObject t1 = (GameObject)(t0[i]);

            if (_prefab.ContainsKey(t1.name))

                continue;

            _prefab[t1.name] = t1;

        }

    }


    //프리펩 하나만 읽어오기
    public void LoadPrefab(string objectPath)

    {

        GameObject gameObject = (GameObject)Resources.Load(objectPath, typeof(GameObject));

        _prefab.Add(gameObject.name, gameObject);

    }


    //전체 프리펩 삭제
    public void RemoveAllPrefab()

    {

        if (_prefab.Count == 0)

            return;

        _prefab.Clear();

    }


    //프리펩 복사
    public GameObject ClonePrefab(string key)

    {

        GameObject t0 = null;

        if (_commonPrefab.ContainsKey(key))

        {

            t0 = (GameObject)(GameObject.Instantiate(_commonPrefab[key]));

        }

        else if (_prefab.ContainsKey(key))

        {

            t0 = (GameObject)(GameObject.Instantiate(_prefab[key]));

        }



        if (t0 == null)

        {

            Debug.Log(string.Format("ResourceManager Clone is failed, [key={0}]", key));

            return null;

        }



        t0.name = key + "_Clone";

        return t0;

    }





}

