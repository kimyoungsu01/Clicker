using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageOption : MonoBehaviour
{
    [Header("옵션창")]
    public GameObject uiOption;
    public Button backBtn;
    public Button mainBtn;

    public PlayerData playerData;
    public PlayerStat playerStat;

    public void Start()
    {
        backBtn.onClick.AddListener(ClickBackBtn);
        mainBtn.onClick.AddListener(ClickMainBtn);

        uiOption.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 현재 상태의 반대로 바꿔줌 (토글 기능)
            uiOption.SetActive(!uiOption.activeSelf);

            Debug.Log(uiOption.activeSelf ? "옵션창 열림" : "옵션창 닫힘");
        }
    }

    public void ClickBackBtn()
    {
        uiOption.SetActive(false);
    }

    public void ClickMainBtn()
    {
        GameManager.Instance.SaveUserData();
        GameManager.Instance.transition.LoadScene(0);
    }
}
