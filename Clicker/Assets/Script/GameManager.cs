using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public Stage Stage { get; private set; }
    //public Player player { get; private set; }
    //public Enemy enemy { get; private set; }
    //public Item item { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else { Destroy(gameObject); }
    }

    public void PlayerData()
    {
        
    }
}
