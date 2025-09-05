using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CostManager : MonoBehaviour // <-���̵� ��밡���Ѱ�?
{
    public int pointCount { get;  set; }
    public int goldCount { get;  set; }
    private PlayerData playerData;
    public MoneyScore moneyScore;

    public CanvasGroup uiCost;
    public GameObject zeroGoldPanel;
    public GameObject zeroPointPanel;

    public static CostManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != null)
        {
            Destroy(gameObject);
        }
        GameManager.Instance.Init();
    }


    public void Init(PlayerData Data) 
    {
        Debug.Log(Data);
        playerData = Data;
        goldCount = playerData.goldCount;
        pointCount = playerData.pointCount;
        moneyScore.Init();
    }

    public int GoldSub(int amount)
    {
        
        // ������ ��� ������ ������ �ִ� ��� �纸�� �۴ٸ�
        if (goldCount >= amount)
        {
            goldCount -= amount;
            playerData.goldCount = goldCount;
            moneyScore.ReadGold();
            //GameManager.Instance.SaveUserData();
        }

        else
        {
            // ������ ��� ������ ������ �ִ� ��� �纸�� ũ�ٸ�
            OnZeroGold();
        }
        return goldCount;
    }

    public int PointSub(int amount)
    {
        if (pointCount >= amount)
        {
            pointCount -= amount;
            playerData.pointCount = pointCount;
            moneyScore.ReadPoint();
            //GameManager.Instance.SaveUserData();
        }

        else
        {
            OnZeroPoint();
        }
        return pointCount;
    }

    public void OnZeroGold()
    {
        zeroGoldPanel.SetActive(true);
        // õõ�� ������� ȿ�� �ֱ�
        if(zeroPointPanel == true) 
        {
            StartCoroutine(FadeOutPanel(uiCost, 2f));
        }
    }

    public void OnZeroPoint()
    {
        zeroPointPanel.SetActive(true);
        // õõ�� ������� ȿ�� �ֱ�
        if (zeroPointPanel == true)
        {
            StartCoroutine(FadeOutPanel(uiCost, 2f));
        }
    }

    private IEnumerator FadeOutPanel(CanvasGroup canvasGroup, float delay)
    {
        canvasGroup.alpha = 1f;

        // ������ �ð���ŭ ����
        yield return new WaitForSeconds(delay);

        // õõ�� �������
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime; // 1�ʿ� 1�� �پ��
            yield return null;
        }

        zeroGoldPanel.SetActive(false);
    }
}
