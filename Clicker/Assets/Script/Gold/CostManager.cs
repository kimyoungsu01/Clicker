using UnityEngine;

public class CostManager : MonoBehaviour // <-���̵� ��밡���Ѱ�?
{
    public int pointCount { get; private set; }
    public int goldCount { get; private set; }

    public GameObject zeroGold;

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
            OnZeroGold();
        }

    }

    public void OnZeroGold()
    {
        zeroGold.SetActive(true);
    }
}
