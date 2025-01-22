using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    public GameObject gas;
    private Vector3 gasPos;
    public Slider gasSlider;
    public GameObject endUI;
    public Button endButton;
    public Button startButton;
    public GameObject startUI;
    public bool isGameOver;
    public static GameManager Instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        // 인스턴스 중복 방지
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 기존 인스턴스가 있으면 새로운 오브젝트 삭제
            return;
        }

        Instance = this; // 현재 인스턴스를 설정
        DontDestroyOnLoad(gameObject); // 씬이 변경되어도 오브젝트 유지
    }
    void Start()
    {
        isGameOver = true;
        gasPos = new Vector3(0, 5.5f, 0);
        gasSlider.value = 100f;
        StartCoroutine(SpawnGas());
        StartCoroutine(GasConsume());
        endButton.onClick.AddListener(OnclickEndButton);
        startButton.onClick.AddListener(OnclickStartButton);
        Time.timeScale = 0;
    }

    private void OnclickStartButton()
    {
        startUI.SetActive(false);
        Time.timeScale = 1;
        isGameOver = false;
    }

    private void OnclickEndButton()
    {
        endUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private IEnumerator SpawnGas()
    {
        while (true)
        {
            float ranTime = Random.Range(1f, 3f); 
            yield return new WaitForSeconds(ranTime);

            GasPosition(); // 위치 설정
            Instantiate(gas, gasPos, transform.rotation);
        }
    }
    private IEnumerator GasConsume()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            gasSlider.value -= 10f;
            if (gasSlider.value <= 0)
            {
                endUI.SetActive(true);
                Time.timeScale = 0;
                isGameOver = true;
            }
        }
    }
    void GasPosition()
    {
        int ranNum = Random.Range(1, 4);
        if (ranNum == 1)
        {
            gasPos = new Vector3(-1.2f, 5.5f, 0);
        }
        else if (ranNum == 2)
        {
            gasPos = new Vector3(0, 5.5f, 0);
        }
        else
        {
            gasPos = new Vector3(1.2f, 5.5f, 0);
        }
    }
}
