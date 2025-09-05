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

    [SerializeField] Transition transition;

    public static MainSceneLoader Instance { get; private set; }

    public bool isSave; 

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
        newStageBtn.onClick.AddListener(OnNewStage);
        loadStageBtn.onClick.AddListener(OnLoadStage);
        optionBtn.onClick.AddListener(OnOption);
        backBtn.onClick.AddListener(OnBack);
    }

    public void OnNewStage() 
    {
        transition.LoadScene(1);
        isSave = false;
    }

    public void OnLoadStage() 
    {
        // 플레이어 저장값 불러와서 
        GameManager.Instance.LoadUserData();
        //anim.SetTrigger("FadeOut");
        transition.LoadScene(1);
        isSave = true;
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
