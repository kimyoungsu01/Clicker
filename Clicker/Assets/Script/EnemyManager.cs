using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public Stagecnt stagecnt;

    private void Start()
    {
        GameObject enemy = Resources.Load<GameObject>("Prefabs/Triangleenemy");
        Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        GameManager.Instance.LoadUserData();
    }

    // 에너미 스크립트 활용하여 캐릭터 리스폰 추가
    public void Respwan()
    {
        Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
