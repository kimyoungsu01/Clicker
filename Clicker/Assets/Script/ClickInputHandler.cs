using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInputHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 클릭 감지
        {

            Debug.Log("Valid Click!");

            // 1) UI 위인지 체크
            // 2) 게임 상태 체크 (Paused면 무시)
            // 3) 조건 통과 시 "유효 클릭 발생" 신호 발행
        }
    }
}
