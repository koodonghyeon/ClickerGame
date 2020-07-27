using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class cShopButton : MonoBehaviour
//{
//    public Text _TabPrice;
//    public Text _TabDamage;
//    public Text _UnitAttack;
//    public Text _UnitSpeed;
//    public Text _UnitLV;

//    //cUintData UnitData = new cUintData();
//    public void Init()
//    {
//        UnitData= cGameInfo.Instance.Unit.LoadData();
//    }
//    public void TabUPgrade()
//    {
    
//    }
//    public void UnitUpgrade()
//    {
        
//        cUintData Unit = cGameInfo.Instance.Unit.LoadData();
//        if (Unit.UnitLevel <= 20)
//        {
//            Unit.UnitAttack += 5;
//            Unit.UnitSpeed += 0.02f;
//            ++Unit.UnitLevel;
//            cGameInfo.Instance.Unit.setUnitData(Unit.UnitAttack, Unit.UnitSpeed);
//            _UnitAttack.text = "유닛 공격력 증가량 : " + Unit.UnitAttack.ToString();
//            _UnitAttack.text = "유닛 공격속도 증가량 : " + Unit.UnitSpeed.ToString();
//            _UnitLV.text = "유닛LV" + Unit.UnitLevel.ToString();
//        }
//    }
//}
