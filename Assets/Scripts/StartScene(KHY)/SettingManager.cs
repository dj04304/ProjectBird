using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SettingManager : MonoBehaviour
{
    public GameObject SettingCanvas;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    public void QuitGame()
    {
        Debug.Log("QuitGame Event");
        Application.Quit();
    }

    public void QuitSetting()
    {
        Debug.Log("QuitSetting Event");
        SettingCanvas.SetActive(false);
    }

    
}
