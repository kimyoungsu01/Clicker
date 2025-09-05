using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneLoader : MonoBehaviour
{
    [SerializeField]

    [Header("씬 전환")]
    public Button newStageBtn;
    public Button loadStageBtn;
    public Button optionBtn;
    public GameObject option;
    public Button backBtn;

    

    public static MainSceneLoader Instance { get; private set; }

     

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        //else
        //    Destroy(this.gameObject);
        
    }

    private void Start()
    {
        newStageBtn.onClick.AddListener(GameManager.Instance.OnNewStage);
        loadStageBtn.onClick.AddListener(GameManager.Instance.OnLoadStage);
        optionBtn.onClick.AddListener(OnOption);
        backBtn.onClick.AddListener(OnBack);
    } 

    public void OnOption() 
    {
        option.SetActive(true);
    }

    public void OnBack() 
    {
        option.SetActive(false);
    }
}
