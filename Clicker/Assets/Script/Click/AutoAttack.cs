using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    // ����Ŭ���� ���� -> ����Ŭ�� ����, ���� -> ����Ŭ�� ������ -> ���� �� ������ ����Ŭ���� �� (�ٸ� Ŭ������ ����x)
    // ����Ŭ�� bool ���η� �Ǵ�, ���� ���Ŀ��� true; ���� �������� false;
    // �ڷ�ƾ ��� �ʼ�

    [SerializeField] private bool autoClick = false;
    [SerializeField] private int autoClickLevel = 1;
    [SerializeField] private float baseInterval = 3.0f; // �⺻ ��Ÿ��
    [SerializeField] private float perLevelMultiplier = 0.90f; // ���� 1�� 10%�� �� ������(0.90^level)
    [SerializeField] private float minInterval = 0.15f;

    Coroutine loop;

    float CurrentInterval()
    {
        int lv = Mathf.Max(0, autoClickLevel);
        float interval = baseInterval;

        for (int i = 0; i < lv; i++)
            interval *= perLevelMultiplier;           // ���� 1���� 0.9��ó�� ���̱�

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
