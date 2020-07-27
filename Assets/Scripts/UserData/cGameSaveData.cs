using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class cGameSaveData 
{
    int _currStageIndex=1;
    int _maxClearStageIndex;

    float _SaveCurrHP=100;
    float _SaveMaxHP=100;
    public int currStageIndex
    {
        get { return _currStageIndex; }
        set { _currStageIndex = value; }
    }
    public int maxClearStageIndex
    {
        get { return _maxClearStageIndex; }
        set { _maxClearStageIndex = value; }
    }
    public float SaveCurrnt
    {
        get { return _SaveCurrHP; }
        set { _SaveCurrHP = value; }
    }
    public float SaveMaxHP
    {
        get { return _SaveMaxHP; }
        set { _SaveMaxHP = value; }
    }

}
