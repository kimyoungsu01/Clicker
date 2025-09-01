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
        //GameManager.Instance.LoadUserData();
        //Stage[] stages = new 
        //SceneManager.LoadScene(LoadUserData);
    }
}
