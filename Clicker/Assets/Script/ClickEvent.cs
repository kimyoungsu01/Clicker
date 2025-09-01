using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public bool isPaused = false;
    public bool assumeMonsterPresent = true; // 몬스터를 가정


    public UnityEvent onAttack; // 테스트연출
    // public UnityEvent<Vector2> onClickValidated; // 유효 클릭 좌표 전달

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        { 
            return; 
        }

        if (isPaused)
        {
            return;
        }

        if (EventSystem.current && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!assumeMonsterPresent)
        {
            return;        
        }

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // onClickValidated?.Invoke(worldPos);

        Debug.Log("클릭하여 데미지를 주었음");
        onAttack?.Invoke(); // 테스트용

    }





}
