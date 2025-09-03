using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    // 오토클릭을 구매 -> 오토클릭 생성, 동작 -> 오토클릭 레벨업 -> 점점 더 빠르게 오토클릭을 함 (다른 클릭에는 연관x)
    // 오토클릭 bool 여부로 판단, 구매 이후에는 true; 구매 이전에는 false;
    // 코루틴 사용 필수

    [SerializeField] private bool autoClick = false;
    [SerializeField] private int autoClickLevel = 1;
    [SerializeField] private float baseInterval = 3.0f; // 기본 쿨타임
    [SerializeField] private float perLevelMultiplier = 0.90f; // 레벨 1당 10%씩 더 빠르게(0.90^level)
    [SerializeField] private float minInterval = 0.15f;

    Coroutine loop;

    float CurrentInterval()
    {
        int lv = Mathf.Max(0, autoClickLevel);
        float interval = baseInterval;

        for (int i = 0; i < lv; i++)
            interval *= perLevelMultiplier;           // 레벨 1마다 0.9배처럼 줄이기

        if (interval < minInterval)
            interval = minInterval;

        return interval;
    }


    public void autoClickUnlock()
    {
        if (autoClick) return;
        {
            autoClick = true;
            RestartLoop();
        }
    }

    public void autoClickUpgrade()
    {
        if (!autoClick)
        {
            autoClickUnlock(); 
            return;
        }
        autoClickLevel++;
        RestartLoop();
    }

    private void OnEnable()
    {
        if (autoClick) 
        {
            RestartLoop();
        }
    }

    private void OnDisable()
    {
        if (loop != null)
        {
            StopCoroutine(loop);
        }

        loop = null;
    }

    private IEnumerator AutoLoop()
    {
        while (autoClick)
        {
            AttackOnce();
        }
        yield return new WaitForSeconds(CurrentInterval());
    }

    void RestartLoop()
    {
        if (loop != null)
        {
            StopCoroutine(loop);
        }

        loop = StartCoroutine(AutoLoop());

    }

    void AttackOnce()
    {
        if (!target)
        {
            target = FindObjectOfType<EnemyHealth>();

            if (tar)
        }
    }




}
