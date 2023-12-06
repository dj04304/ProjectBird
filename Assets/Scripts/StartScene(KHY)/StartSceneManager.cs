using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string PlayerName;
    public GameObject MainCanvas;
    public GameObject SettingCanvas;
    public GameObject GetNameScreen;
    public GameObject ScoreBoard;
    public GameObject Guide;

    public GameObject[] GuideList = new GameObject[] { };
    private int GuideIndex;
    
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
        SoundManager.Instance.playButtonEffect();
        Debug.Log("gameStart Event");
        MainCanvas.SetActive(false);
        GuideInit();
        //SceneManager.LoadScene("TestGameScene(KHY)");
    }
    public void setName()
    {
        SoundManager.Instance.playButtonEffect();
        Debug.Log("setName Event");
        GetNameScreen.SetActive(true);
    }
    public void showScoreboard()
    {
        ScoreBoard.SetActive(true);
        SoundManager.Instance.playButtonEffect();
        Debug.Log("showScoreboard Event");
    }
    public void showSetting()
    {
        Debug.Log("showSetting Event");
        SoundManager.Instance.playButtonEffect();
        SettingCanvas.SetActive(true);
    }
    private void StartSceneInit()
    {
        MainCanvas.SetActive(true);
        SettingCanvas.SetActive(false);
        GetNameScreen.SetActive(false);
        ScoreBoard.SetActive(false);
        Guide.SetActive(false);
        
    }
    public void GuideSelectPrev()
    {
        SoundManager.Instance.playButtonEffect();
        if (GuideIndex != 0)
        {
            deleteGuide(GuideIndex);
            GuideIndex--;
            ShowGuide(GuideIndex);
        }
    }
    public void GuideSelectFollow()
    {
        SoundManager.Instance.playButtonEffect();
        if (GuideIndex == GuideList.Length - 1)
        {
            SceneManager.LoadScene("MainScene");
        }
        if (GuideIndex != GuideList.Length-1)
        {
            deleteGuide(GuideIndex);
            GuideIndex++;
            ShowGuide(GuideIndex);
        }
    }
    public void QuitGuide()
    {
        SoundManager.Instance.playButtonEffect();
        Guide.SetActive(false);
        MainCanvas.SetActive(true);
    }
    private void GuideInit()
    {
        GuideIndex = 0;
        Guide.SetActive(true);
        GuideList[0].SetActive(true);
        for(int cnt=1; cnt < GuideList.Length; cnt++)
        {
            GuideList[cnt].SetActive(false);
        }
    }
    private void ShowGuide(int g_index)
    {
        GuideList[g_index].SetActive(true);
    }
    private void deleteGuide(int g_index)
    {
        GuideList[g_index].SetActive(false);
    }

}
