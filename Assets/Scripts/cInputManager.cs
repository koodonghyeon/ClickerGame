using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//터치이벤트 처리할 클래스 따로만듬 ㅇㅇ
public class cInputManager : MonoBehaviour
{
   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cGameScene.Instance.TouchScreen(Input.mousePosition);
        }
    }
}
