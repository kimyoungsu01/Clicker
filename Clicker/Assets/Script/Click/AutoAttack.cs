using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    // 오토클릭을 구매 -> 오토클릭 생성, 동작 -> 오토클릭 레벨업 -> 점점 더 빠르게 오토클릭을 함
    // 오토클릭 bool 여부로 판단 -> 구매 이전에는 false; 구매 이후에는 true; 이후 중복 구매시 레벨up  
    // 코루틴 사용

    [SerializeField] private bool autoClick = false;
    [SerializeField] private int autoClickLevel = 1;
    [SerializeField , HideInInspector] private float baseInterval = 2.0f; // 기본 쿨타임
    [SerializeField , HideInInspector] private float perLevelMultiplier = 0.90f; // 레벨 1당 10%씩 더 빠르게(0.90^level)
    [SerializeField , HideInInspector] private float minInterval = 0.15f;
    [SerializeField , HideInInspector] private int damagePerShot = 1;
    [SerializeField , HideInInspector] private Enemy target;

    private Coroutine loop;

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
        if (autoClick)
        {
            return;
        }
            autoClick = true;
            RestartLoop();
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
            yield return new WaitForSeconds(CurrentInterval());
        }
        
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
        if (!target || !target.gameObject || !target.gameObject.activeInHierarchy)
        {
            target = FindObjectOfType<Enemy>();
        }

        if (!target)
        {
            return;
        }

        if (target.hpImage && target.hpImage.fillAmount <= 0f)
        {
            return;
        }

        target.Takedamage();

        Vector2 pos = (Vector2)target.transform.position; // + Vector2.up * 0.2f;
        ParticleManager.instance?.PlayClick(pos);

    }




}
