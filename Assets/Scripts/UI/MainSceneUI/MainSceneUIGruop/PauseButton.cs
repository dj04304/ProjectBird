using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = gameObject.transform.Find("Image").GetComponent<Button>();
    }

    public void SetUIManager(UIManager UIManager)
    {
        _button.onClick.AddListener(() => UIManager.PauseButtonClick());
    }
}
