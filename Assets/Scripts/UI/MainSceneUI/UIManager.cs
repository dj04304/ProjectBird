using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Canvas _mainSceneUI;

    private void Awake()
    {
        _mainSceneUI = Resources.Load<Canvas>("Prefabs/UI/MainSceneUI/MainSceneUIGroup");
        
    }

    private void Start()
    {
        Instantiate(_mainSceneUI);
    }
}
