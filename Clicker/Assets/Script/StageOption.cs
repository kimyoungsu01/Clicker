using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageOption : MonoBehaviour
{
    [Header("�ɼ�â")]
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
            // ���� ������ �ݴ�� �ٲ��� (��� ���)
            uiOption.SetActive(!uiOption.activeSelf);

            Debug.Log(uiOption.activeSelf ? "�ɼ�â ����" : "�ɼ�â ����");
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
