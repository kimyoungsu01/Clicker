using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public Enemy enemy;

    void Awake()
    {
      if(Instance == null) Instance = this;
      else Destroy(gameObject);
    }
}
