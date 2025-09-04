using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public bool isPaused = false;
    private Enemy enemy;

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

        if (enemy == null || !enemy.isActiveAndEnabled)
        {
            enemy = FindObjectOfType<Enemy>();
        }

        if (enemy == null)
        {
            return;
        }

        Vector2 worldPos2D = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (enemy.IsDead)
        //{
        //    return;
        //}

        enemy.Takedamage();

        ParticleManager.instance?.PlayClick(worldPos2D);


    }
    




}
