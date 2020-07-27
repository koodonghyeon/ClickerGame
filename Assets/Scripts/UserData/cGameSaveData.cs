using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class cGameSaveData 
{
    int _currStageIndex=1;
    int _maxClearStageIndex=1;



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
  

}
public class cHPData 
{
    HPIndex _Index;
    int _SaveCurrHP = 100;
    int _SaveMaxHP = 100;
    public HPIndex Index
    {
        get { return _Index; }
        set { _Index = value; }
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

//public class cUintData
//{

//    int _UnitPrice;
//    int _TabPrice;
//    int _TabDamage;
//    int _UnitAttack = 0;
//    float _UnitSpeed = 0;
//    int _touchLevel = 1;
//    int _UnitLevel = 1;
//    public int UnitPrice
//    {
//        get { return _UnitPrice; }
//        set { _UnitPrice = value; }
//    }
//    public int TabPrice
//    {
//        get { return _TabPrice; }
//        set { _TabPrice = value; }
//    }
//    public int TabDamage
//    {
//        get { return _TabDamage; }
//        set { _TabDamage = value; }
//    }

//    public int UnitAttack
//    {
//        get { return _UnitAttack; }
//        set { _UnitAttack = value; }
//    }

//    public float UnitSpeed
//    {
//        get { return _UnitSpeed; }
//        set { _UnitSpeed = value; }
//    }
//    public int touchLevel
//    {
//        get { return _touchLevel; }
//        set { _touchLevel = value; }
//    }
//    public int UnitLevel
//    {
//        get { return _UnitLevel; }
//        set { _UnitLevel = value; }

//    }
//}

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

