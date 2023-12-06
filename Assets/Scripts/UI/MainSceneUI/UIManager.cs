using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Canvas _mainSceneUI;
    private Canvas _mainSceneUIInstance; // 인스턴스화 된 팝업창
    private GameObject _pausePopup;
    private GameObject _pausePopupInstance; // 인스턴스화 된 팝업창

    private CurrentScoreText _currentScoreText;
    private CurrentLifeUI _currentLifeUI;
    private PauseButton _pauseButtonScript;
    private PausePopup _pausePopupScript;
    private Canvas _GameOverTxt;

    public event Action<bool> OnPauseButton;
    public event Action OnRestartButton;
    public event Action OnHomeButton;

    private bool _isPause = false;

    private void Awake()
    {
        if (_mainSceneUIInstance != null)
        {
            Destroy(_mainSceneUIInstance);
        }
        _mainSceneUI = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/MainSceneUIGroup");
        _pausePopup = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/PausePopup");
        _GameOverTxt = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/GameOverTxt");

        InstantiatePrefab(out Canvas mainSceneUI);
        _mainSceneUIInstance = mainSceneUI;
        UiComponentLoading();
        ManagerObjectSend();
    }

    private void Start()
    {
        OnPauseButton += OnPauseWindow;

        _GameOverTxt = Instantiate(_GameOverTxt);
        _GameOverTxt.gameObject.SetActive(false);
    }

    /* 라이프 UI 테스트용 변수값 증감 코드 (현재 주석처리)
    #region
    float time = 0.0f;
    bool Operator = true;

    private int testlife = 0;

    private void Update()
    {
        time += Time.deltaTime;

        testmethod();
    }

    private void testmethod()
    {
        if (testlife == 10)
        {
            Operator = false;
        }
        else if (testlife == 0)
        {
            Operator = true;
        }

        if (time >= 0.25f && Operator)
        {
            testlife += 1;
            time = 0.0f;
        }
        else if (time >= 0.25f && !Operator)
        {
            testlife -= 1;
            time = 0.0f;
        }

        SendCurrentLife(testlife);
    }
    #endregion
    */

    private void UiComponentLoading()
    {
        _pauseButtonScript = _mainSceneUIInstance.transform.Find("PauseButton").GetComponent<PauseButton>();
        _currentScoreText = _mainSceneUIInstance.transform.Find("Score").GetComponent<CurrentScoreText>();
        _pausePopupScript = _pausePopupInstance.transform.GetComponent<PausePopup>();
        _currentLifeUI = _mainSceneUIInstance.transform.Find("Life").GetComponent<CurrentLifeUI>();
    }

    private void InstantiatePrefab(out Canvas sendmainSceneUI)
    {
        Canvas mainSceneUI = Instantiate(_mainSceneUI);
        sendmainSceneUI = mainSceneUI;
        _pausePopupInstance = Instantiate(_pausePopup);
        _pausePopupInstance.transform.SetParent(mainSceneUI.transform, false);
        _pausePopupInstance.SetActive(false);

    }


    public void PauseButtonClick()
    {
        _isPause = !_isPause;
        OnPauseButton?.Invoke(_isPause);
        Debug.Log(_isPause);
    }

    public void RestartButtonClick()
    {
        OnRestartButton?.Invoke();
    }

    public void HomeButtonClick()
    {
        OnHomeButton?.Invoke();
    }

    public void SendCurrentScore(int score)
    {
        _currentScoreText.ChangeCurrentScore = score;
    }

    public void SendCurrentLife(int life)
    {
        _currentLifeUI.CurrentLifeChange = life;
    }

    private void OnPauseWindow(bool isPause)
    {
        if (_isPause)
        {
            _pausePopupInstance.SetActive(true);
        }
        else
        {
            _pausePopupInstance.SetActive(false);
        }
    }

    public void ManagerObjectSend()
    {
        _pauseButtonScript.SetUIManager(gameObject.GetComponent<UIManager>());
        _pausePopupScript.SetUIManager(gameObject.GetComponent<UIManager>());
    }

    public void SetGameOverText()
    {
        Debug.Log("호출?");
        _GameOverTxt.gameObject.SetActive(true);
    }

}
