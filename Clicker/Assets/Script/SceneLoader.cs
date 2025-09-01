using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button NewStageBtn;
    public Button LoadStageBtn;

    private void Start()
    {
        NewStageBtn.onClick.AddListener(OnNewStage);
        LoadStageBtn.onClick.AddListener(OnLoadStage);
    }

    public void OnNewStage() 
    {
        SceneManager.LoadScene(1);
    }

    public void OnLoadStage() 
    {
        SceneManager.LoadScene("각 스테이지 값 추가");
    }
}
