using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]

    [Header("씬 전환")]
    public Button newStageBtn;
    public Button loadStageBtn;
    public Button optionBtn;
    public GameObject option;
    public Button backBtn;
public GameObject zeroGold;

    private void Start()
    {
        newStageBtn.onClick.AddListener(OnNewStage);
        loadStageBtn.onClick.AddListener(OnLoadStage);
        optionBtn.onClick.AddListener(OnOption);
        backBtn.onClick.AddListener(OnBack);
    }

    public void OnNewStage() 
    {
        SceneManager.LoadScene(1);
    }

    public void OnLoadStage() 
    {
        // 플레이어 저장값 불러와서 
        GameManager.Instance.LoadUserData();
        SceneManager.LoadScene(1);
    }

    public void OnOption() 
    {
        option.SetActive(true);
    }

    public void OnBack() 
    {
        option.SetActive(false);
    }

    public void OnZeroGold() 
    {
        zeroGold.SetActive(true);
    }
}
