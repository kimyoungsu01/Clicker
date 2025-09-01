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

    

    // 클릭 이펙트
    [Header("Click Effect")]
    [SerializeField] private ParticleSystem clickEffectPrefab; 
    [SerializeField] private float effectZ = 0f;              
    [SerializeField] private bool autoDestroy = true;          
    [SerializeField] private float extraLifetime = 0.1f;       

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
        Vector2 worldPos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 worldPos = new Vector3(worldPos2D.x, worldPos2D.y, effectZ); // 파티클 표시용 Z 보정

        Debug.Log("클릭하여 데미지를 주었음");
        onAttack?.Invoke(); // 테스트용

        // 파티클 인스턴스 생성/재생
        if (clickEffectPrefab != null)
        {
            ParticleSystem ps = Instantiate(clickEffectPrefab, worldPos, Quaternion.identity); // 클릭 지점에 생성
            ps.Play(); // 즉시 재생

            if (autoDestroy)
            {
                var main = ps.main;
                float duration = main.duration;

                
                float startLifetimeMax;
                if (main.startLifetime.mode == ParticleSystemCurveMode.TwoConstants)
                    startLifetimeMax = main.startLifetime.constantMax;
                else
                    startLifetimeMax = main.startLifetime.constant; 

                float killAfter = duration + startLifetimeMax + extraLifetime;
                Destroy(ps.gameObject, killAfter); 
            }
        }
        else
        {
            Debug.LogWarning("[ClickEvent] clickEffectPrefab이 비어있습니다. Inspector에 파티클 프리팹을 할당하세요.");
        }

        
    }





}
