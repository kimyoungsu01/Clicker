using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]

    [Header("씬 전환")]
    public Button newStageBtn;
    public Button loadStageBtn;
    public GameObject zeroGold;

    [Header("씬 오디오")]
    public AudioClip mainScene;
    public AudioClip StageScene;

    private void Start()
    {
        newStageBtn.onClick.AddListener(OnNewStage);
        loadStageBtn.onClick.AddListener(OnLoadStage);
    }

    public void OnNewStage() 
    {
        SceneManager.LoadScene("Stage1");
        SoundManager.instance.ChangeBGM(mainScene);
    }

    public void OnLoadStage() 
    {
        // 플레이어 저장값 불러와서 
        GameManager.Instance.LoadUserData();
        // SetActive로 true해주기
        //StageScene.SetActive(true);
        //MainButton.SetActive(false);
        //BackSpace.SetActive(true);
        SoundManager.instance.ChangeBGM(StageScene);
    }

    public void OnZeroGold() 
    {
        zeroGold.SetActive(true);
    }
}
