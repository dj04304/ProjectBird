using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Canvas _mainSceneUI;
    private GameObject _gameMap;
    private GameObject _pausePopup;
    private GameObject _pausePopupInstance; // 인스턴스화 된 팝업창

    private CurrentScoreText _currentScoreText;
    private CurrentLifeUI _currentLifeUI;

    public event Action OnPauseButton;

    private void Awake()
    {
        _mainSceneUI = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/MainSceneUIGroup");
        _gameMap = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/GameMap");
        _pausePopup = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/PausePopup");
    }

    private void Start()
    {
        InstantiatePrefab(out Canvas mainSceneUI);
        _currentScoreText = mainSceneUI.transform.Find("Score").GetComponent<CurrentScoreText>();
        SendCurrentScore(200);
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
        OnPauseButton?.Invoke();
    }

    public void SendCurrentScore(int score)
    {
        _currentScoreText.ChangeCurrentScore = score;
    }
}
