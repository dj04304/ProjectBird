using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePopup : MonoBehaviour
{
    private enum ButtonList
    {
        CloseButton, RestartButton, QuitButton
    }

    private Dictionary<ButtonList, Button> _buttonComponents = new Dictionary<ButtonList, Button>();

    private void Awake()
    {
        foreach (ButtonList buttonname in Enum.GetValues(typeof(ButtonList)))
        {
            Button button = gameObject.transform.Find("Contents").Find("Background").Find(buttonname.ToString()).GetComponent<Button>();
            _buttonComponents.Add(buttonname, button);
        }
    }

    private void SetButtonClickEvent(ButtonList buttonList, UnityEngine.Events.UnityAction action)
    {
        _buttonComponents.TryGetValue(buttonList, out Button button);

        button.onClick.AddListener(action);
    }

    public void SetUIManager(UIManager UIManager)
    {
        SetButtonClickEvent(ButtonList.CloseButton, () => UIManager.PauseButtonClick());
        SetButtonClickEvent(ButtonList.RestartButton, () => UIManager.RestartButtonClick());
        SetButtonClickEvent(ButtonList.QuitButton, () => UIManager.HomeButtonClick());
    }
}
