using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public bool isPaused = false;
    public bool assumeMonsterPresent = true; // ëª¬ìŠ¤í„°ë¥¼ ê°€ì •


    public UnityEvent onAttack; // í…ŒìŠ¤íŠ¸ì—°ì¶œ
    // public UnityEvent<Vector2> onClickValidated; // ìœ íš¨ í´ë¦­ ì¢Œí‘œ ì „ë‹¬

    

    // Å¬¸¯ ÀÌÆåÆ®
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
        Vector3 worldPos = new Vector3(worldPos2D.x, worldPos2D.y, effectZ); // ÆÄÆ¼Å¬ Ç¥½Ã¿ë Z º¸Á¤

        Debug.Log("í´ë¦­í•˜ì—¬ ë°ë¯¸ì§€ë¥¼ ì£¼ì—ˆìŒ");
        onAttack?.Invoke(); // í…ŒìŠ¤íŠ¸ìš©

        // ÆÄÆ¼Å¬ ÀÎ½ºÅÏ½º »ı¼º/Àç»ı
        if (clickEffectPrefab != null)
        {
            ParticleSystem ps = Instantiate(clickEffectPrefab, worldPos, Quaternion.identity); // Å¬¸¯ ÁöÁ¡¿¡ »ı¼º
            ps.Play(); // Áï½Ã Àç»ı

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
            Debug.LogWarning("[ClickEvent] clickEffectPrefabÀÌ ºñ¾îÀÖ½À´Ï´Ù. Inspector¿¡ ÆÄÆ¼Å¬ ÇÁ¸®ÆÕÀ» ÇÒ´çÇÏ¼¼¿ä.");
        }

        
    }





}
