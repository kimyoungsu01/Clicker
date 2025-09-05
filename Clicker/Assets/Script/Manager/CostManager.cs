using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CostManager : MonoBehaviour // <-없이도 사용가능한가?
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
        
        // 아이템 골드 가격이 가지고 있는 골드 양보다 작다면
        if (goldCount >= amount)
        {
            goldCount -= amount;
            playerData.goldCount = goldCount;
            moneyScore.ReadGold();
            //GameManager.Instance.SaveUserData();
        }

        else
        {
            // 아이템 골드 가격이 가지고 있는 골드 양보다 크다면
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
        // 천천히 사라지는 효과 넣기
        if(zeroPointPanel == true) 
        {
            StartCoroutine(FadeOutPanel(uiCost, 2f));
        }
    }

    public void OnZeroPoint()
    {
        zeroPointPanel.SetActive(true);
        // 천천히 사라지는 효과 넣기
        if (zeroPointPanel == true)
        {
            StartCoroutine(FadeOutPanel(uiCost, 2f));
        }
    }

    private IEnumerator FadeOutPanel(CanvasGroup canvasGroup, float delay)
    {
        canvasGroup.alpha = 1f;

        // 지정된 시간만큼 유지
        yield return new WaitForSeconds(delay);

        // 천천히 사라지게
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime; // 1초에 1씩 줄어듦
            yield return null;
        }

        zeroGoldPanel.SetActive(false);
    }
}
