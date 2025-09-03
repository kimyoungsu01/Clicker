using UnityEngine;

public class CostManager : MonoBehaviour // <-���̵� ��밡���Ѱ�?
{
    public int pointCount { get;  set; }
    public int goldCount { get;  set; }

    public GameObject zeroGoldPanel;
    public GameObject zeroPointPanel;

    public static CostManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public CostManager(int Point, int gold) 
    {
        pointCount = Point; // ���� ����Ʈ
        goldCount = gold; // ���� ���
    }
        

    public void GCost(int amount)
    {
        // ������ ��� ������ ������ �ִ� ��� �纸�� �۴ٸ�
        if (goldCount >= amount)
        {
            goldCount -= amount;
            GameManager.Instance.SaveUserData();
        }

        else
        {
            // ������ ��� ������ ������ �ִ� ��� �纸�� ũ�ٸ�
            OnZeroGold();
        }

    }

    public void PCost(int amount)
    {

        if (pointCount >= amount)
        {
            pointCount -= amount;
            GameManager.Instance.SaveUserData();
        }

        else
        {
            OnZeroPoint();
        }

    }

    public void OnZeroGold()
    {
        zeroGoldPanel.SetActive(true);
    }

    public void OnZeroPoint()
    {
        zeroPointPanel.SetActive(true);
    }
}
