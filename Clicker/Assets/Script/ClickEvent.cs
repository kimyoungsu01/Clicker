using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public bool isPaused = false;
    public bool assumeMonsterPresent = true; // ���͸� ����


    public UnityEvent onAttack; // �׽�Ʈ����
    // public UnityEvent<Vector2> onClickValidated; // ��ȿ Ŭ�� ��ǥ ����

    

    // Ŭ�� ����Ʈ
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
        Vector3 worldPos = new Vector3(worldPos2D.x, worldPos2D.y, effectZ); // ��ƼŬ ǥ�ÿ� Z ����

        Debug.Log("Ŭ���Ͽ� �������� �־���");
        onAttack?.Invoke(); // �׽�Ʈ��

        // ��ƼŬ �ν��Ͻ� ����/���
        if (clickEffectPrefab != null)
        {
            ParticleSystem ps = Instantiate(clickEffectPrefab, worldPos, Quaternion.identity); // Ŭ�� ������ ����
            ps.Play(); // ��� ���

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
            Debug.LogWarning("[ClickEvent] clickEffectPrefab�� ����ֽ��ϴ�. Inspector�� ��ƼŬ �������� �Ҵ��ϼ���.");
        }

        
    }





}
