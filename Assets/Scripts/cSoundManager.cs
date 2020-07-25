using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class cSoundManager : MonoBehaviour
{
    private static cSoundManager instance;
    public static cSoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    float _actionVolume = 0.8f;
    private List<AudioSource> _actionSoundList = new List<AudioSource>();
    private void Awake()
    {
        instance = this;
    }
    void OnApplicationQuit()
    {
        instance = null;
    }

    public void Update()
    {
        for (int i = _actionSoundList.Count - 1; i >= 0; --i)
        {
            if (_actionSoundList[i].isPlaying)
                continue;
            Destroy(_actionSoundList[i]);
            _actionSoundList.RemoveAt(i);
        }

    }
    public void PlayActionSound(string key)
    {
        if (key == null || key == "")
            return;

        object go = Resources.Load(string.Format("Sound/{0}", key), typeof(AudioClip));
        AudioClip obj = (AudioClip)go;
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = _actionVolume;
        audioSource.spatialBlend = 0;
        audioSource.ignoreListenerVolume = true;
        audioSource.Stop();
        audioSource.clip = obj;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        _actionSoundList.Add(audioSource);
        audioSource.Play();
    }


}