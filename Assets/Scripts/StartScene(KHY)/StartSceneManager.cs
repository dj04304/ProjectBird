using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string PlayerName;
    public GameObject SettingCanvas;
    public GameObject GetNameScreen;
    void Start()
    {
        StartSceneInit();
        PlayerPrefs.SetString("PlayerName", null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart()
    {
        Debug.Log("gameStart Event");
        SceneManager.LoadScene("TestGameScene(KHY)");
    }

    public void setName()
    {
        Debug.Log("setName Event");
        GetNameScreen.SetActive(true);
    }

    public void showScoreboard()
    {
        Debug.Log("showScoreboard Event");
    }

    public void showSetting()
    {
        Debug.Log("showSetting Event");
        SettingCanvas.SetActive(true);
    }

    private void StartSceneInit()
    {
        SettingCanvas.SetActive(false);
        GetNameScreen.SetActive(false);
    }
}
