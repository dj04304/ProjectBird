using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public MonsterManager monsterManager; // 몬스터 매니저
    public ScoreManager scoreManager; // 스코어 매니저

    private GameObject _uiManager; // UI 매니저 경로
    private GameObject _uiManagerInstance; // 인스턴스화 된 매니저
    private UIManager _uiManagerScript;

    private bool _isGameOver;
    private int _totalScore;

    /// <summary>
    /// 싱글톤
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // _instance가 null 이면 GameObject에 "GameManager" 라는 오브젝트를 생성
                GameObject gameManagerObject = new GameObject("GameManager");
                // _instance 에 GameManager 컴포넌트 추가
                _instance = gameManagerObject.AddComponent<GameManager>();
                // DontDestroyOnLoad로 GameManagerobject가 씬 변환시 Destroy되지 않게끔 설정
                DontDestroyOnLoad(gameManagerObject);
            }
            return _instance;
        }
    }


    private void Awake()
    {
        _uiManager = Resources.Load<GameObject>("Prefabs/UI/UIManager");
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 인스턴스가 중복되어 생성될 경우 파괴해준다.
            Destroy(gameObject);
        }

        // ui매니저 중복생성 방지
        if (_uiManagerInstance != null)
        {
            Destroy(_uiManagerInstance);
        }

        UILoading();
    }

    private void UILoading()
    {
        _uiManagerInstance = Instantiate(_uiManager);
        _uiManagerScript = _uiManagerInstance.GetComponent<UIManager>();

        _uiManagerScript.OnPauseButton += OnPause;
        _uiManagerScript.OnRestartButton += GameRestart;
        _uiManagerScript.OnHomeButton += GoHome;
    }

    // 코루틴 사용
    private IEnumerator EndSceneTransition(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Perform the scene transition after the delay
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if(_isGameOver)
        {
            Debug.Log("Gamemanger 게임 오버!");
            _uiManagerScript.SetGameOverText();
            Time.timeScale = 0.25f;

            StartCoroutine(EndSceneTransition("EndScene", 1.5f));

            _isGameOver = false;
        }

        _uiManagerScript.SendCurrentScore(_totalScore);
    }

    public bool IsGameOver
    {
        get { return _isGameOver; }
        set {  _isGameOver = value; }
    }

    public int TotalScore
    {
        get { return _totalScore; }
        set { _totalScore = value; }
    }

    private void OnPause(bool _isPause)
    {
        if (_isPause)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    private void GameRestart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }

    private void GoHome()
    {
        SceneManager.LoadScene("StartScene");
    }
}
