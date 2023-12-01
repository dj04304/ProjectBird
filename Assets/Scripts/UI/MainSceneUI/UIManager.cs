using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Canvas _mainSceneUI;
    private GameObject _gameMap;
    private GameObject _pausePopup;

    private bool _isPause = false;

    private void Awake()
    {
        _mainSceneUI = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/MainSceneUIGroup");
        _gameMap = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/GameMap");
        _pausePopup = Resources.Load<GameObject>("Prefabs/UI/MainSceneUI/PausePopup");
    }

    private void Start()
    {
        Instantiate(_mainSceneUI);
        Instantiate(_gameMap);
        GameObject pauseWindow = Instantiate(_pausePopup);
        pauseWindow.transform.parent = _mainSceneUI.transform;
    }

    public void OnPauseWindow()
    {
        _isPause = !_isPause;

        _pausePopup.SetActive(_isPause);
    }
}
