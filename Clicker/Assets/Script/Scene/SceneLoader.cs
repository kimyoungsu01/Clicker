using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button newStageBtn;
    public Button loadStageBtn;
    public GameObject zeroGold;

    private void Start()
    {
        newStageBtn.onClick.AddListener(OnNewStage);
        loadStageBtn.onClick.AddListener(OnLoadStage);
    }

    public void OnNewStage() 
    {
        SceneManager.LoadScene("Stage1");
    }

    public void OnLoadStage() 
    {
        // 플레이어 저장값 불러와서 
        GameManager.Instance.LoadUserData();
        // SetActive로 true해주기
        
    }

    public void OnZeroGold() 
    {
        zeroGold.SetActive(true);
    }
}
