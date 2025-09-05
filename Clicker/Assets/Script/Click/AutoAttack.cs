using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    // 오토클릭을 구매 -> 오토클릭 생성, 동작 -> 오토클릭 레벨업 -> 점점 더 빠르게 오토클릭을 함
    // 오토클릭 bool 여부로 판단 -> 구매 이전에는 false; 구매 이후에는 true; 이후 중복 구매시 레벨up  
    // 코루틴 사용

    public static AutoAttack Instance { get; private set; }

    [SerializeField] private bool autoClick = false;
    [SerializeField , HideInInspector] private float baseInterval = 2.0f; 
    [SerializeField , HideInInspector] private float minInterval = 0.15f;
    [SerializeField , HideInInspector] private int damagePerShot = 1;
    [SerializeField , HideInInspector] private Enemy target;

    private Coroutine loop;
    [SerializeField] private PlayerStat stats;

    private bool lastAutoClick;
    private float lastInterval = -1f;

    void Start()
    {
        lastAutoClick = autoClick;
        lastInterval = CurrentInterval();
    }
    void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this); return; 
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    float CurrentInterval()
    {
        
        if (PlayerUpgrade.Instance.playerStat.autoAttackPerSec > 0f)
        {
            float byAPS = 1f / PlayerUpgrade.Instance.playerStat.autoAttackPerSec;
            return Mathf.Max(minInterval, byAPS);
        }
        return Mathf.Max(minInterval, baseInterval);
    }

    void Update()
    {
        
        if (autoClick != lastAutoClick)
        {
            lastAutoClick = autoClick;
            if (autoClick) RestartLoop();
            else StopLoop();
        }

        float now = CurrentInterval();
        if (autoClick && loop != null && !Mathf.Approximately(now, lastInterval))
        {
            lastInterval = now;
            RestartLoop();
        }
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
            if (!target || !target.gameObject || !target.gameObject.activeInHierarchy || target.IsDead)
            {
                target = FindObjectOfType<Enemy>();
                yield return null;
                continue;
            }
            AttackOnce();

            yield return new WaitForSeconds(CurrentInterval());
        }
        loop = null;
    }

    void StopLoop()
    {
        if (loop != null)
        {
            StopCoroutine(loop);
            loop = null;
        }
    }

    void RestartLoop()
    {
        StopLoop();
        lastInterval = CurrentInterval();
        loop = StartCoroutine(AutoLoop());
    }

    void AttackOnce()
    {

        target.Takedamage();

        Vector2 pos = (Vector2)target.transform.position;
        NewParticleManager.instance?.PlayClick(pos);
    }

    public void AutoClickBT()
    {
        if (!autoClick)
        {
            autoClickUnlock();
        }

        else
        {
            autoClickUpgrade();
        }
    }


}
