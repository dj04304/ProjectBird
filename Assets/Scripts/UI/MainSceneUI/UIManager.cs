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
    private GameObject _gameMap;
    private GameObject _pausePopup;
    private GameObject _pausePopupInstance; // 인스턴스화 된 팝업창

    private CurrentScoreText _currentScoreText;
    private CurrentLifeUI _currentLifeUI;
    private PauseButton _pauseButton;
    private Canvas _GameOverTxt;

    public event Action<bool> OnPauseButton;

    private bool _isPause = false;

    private void Awake()
    {
        _mainSceneUI = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/MainSceneUIGroup");
        _gameMap = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/GameMap");
        _pausePopup = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/PausePopup");
        _GameOverTxt = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/GameOverTxt");
    }

    private void Start()
    {
        InstantiatePrefab(out Canvas mainSceneUI);
        _mainSceneUIInstance = mainSceneUI;
        _pauseButton = mainSceneUI.transform.Find("PauseButton").GetComponent<PauseButton>();
        _currentScoreText = _mainSceneUIInstance.transform.Find("Score").GetComponent<CurrentScoreText>();
        OnPauseButton += OnPauseWindow;
        ManagerObjectSend();

        _GameOverTxt = Instantiate(_GameOverTxt);
        _GameOverTxt.gameObject.SetActive(false);
    }

    private void InstantiatePrefab(out Canvas sendmainSceneUI)
    {
        Canvas mainSceneUI = Instantiate(_mainSceneUI);
        sendmainSceneUI = mainSceneUI;
        Instantiate(_gameMap);
        _pausePopupInstance = Instantiate(_pausePopup);
        _pausePopupInstance.SetActive(false);
        _pausePopupInstance.transform.SetParent(mainSceneUI.transform, false);

    }


    public void PauseButtonClick()
    {
        _isPause = !_isPause;
        OnPauseButton?.Invoke(_isPause);
        Debug.Log(_isPause);
    }

    public void SendCurrentScore(int score)
    {
        _currentScoreText.ChangeCurrentScore = score;
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
        _pauseButton.SetUIManager(gameObject.GetComponent<UIManager>());
    }

    public void SetGameOverText()
    {
        Debug.Log("호출?");
        _GameOverTxt.gameObject.SetActive(true);
    }

}
