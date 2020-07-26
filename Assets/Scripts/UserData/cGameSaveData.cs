using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class cGameSaveData 
{
    int _currStageIndex=1;
    int _maxClearStageIndex=1;

    int _SaveCurrHP=100;
    int _SaveMaxHP=100;
    StageIndex _Index;
    public StageIndex Index
    {
        get { return _Index; }
        set { _Index = value; }
    }
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
    public int SaveCurrnt
    {
        get { return _SaveCurrHP; }
        set { _SaveCurrHP = value; }
    }
    public int SaveMaxHP
    {
        get { return _SaveMaxHP; }
        set { _SaveMaxHP = value; }
    }

}
public class ItemSaveData
{
    int _num;
    ItemIndex _itemIndex;
    public int num
    {
        get { return _num; }
        set {_num = value; }
    }
    public ItemIndex itemIndex
    {
        get { return _itemIndex; }
        set { _itemIndex = value; }
    }
}

