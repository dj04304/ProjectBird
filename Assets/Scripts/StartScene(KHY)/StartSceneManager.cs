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

    private GameObject _mainBird;

    public GameObject[] GuideList = new GameObject[] { };
    private int GuideIndex;

    private void Awake()
    {
        _mainBird = Resources.Load<GameObject>("Prefabs/UI/StartScene/StartBird");
    }

    void Start()
    {
        StartSceneInit();
        PlayerPrefs.SetString("PlayerName", null);
        _mainBird = Instantiate(_mainBird);
    }

    public void gameStart()
    {
        Debug.Log("gameStart Event");
        MainCanvas.SetActive(false);
        GuideInit();
        //SceneManager.LoadScene("TestGameScene(KHY)");
    }
    public void setName()
    {
        Debug.Log("setName Event");
        GetNameScreen.SetActive(true);
    }
    public void showScoreboard()
    {
        ScoreBoard.SetActive(true);
        Debug.Log("showScoreboard Event");
    }
    public void showSetting()
    {
        Debug.Log("showSetting Event");
        SettingCanvas.SetActive(true);
    }
    private void StartSceneInit()
    {
        MainCanvas.SetActive(true);
        SettingCanvas.SetActive(false);
        GetNameScreen.SetActive(false);
        ScoreBoard.SetActive(false);
        Guide.SetActive(false);
        GuideIndex = 0;
    }
    public void GuideSelectPrev()
    {
        if(GuideIndex != 0)
        {
            deleteGuide(GuideIndex);
            GuideIndex--;
            ShowGuide(GuideIndex);
        }
    }
    public void GuideSelectFollow()
    {
        if (GuideIndex == GuideList.Length - 1)
        {
            SceneManager.LoadScene("JunTestScene");
        }
        if (GuideIndex != GuideList.Length-1)
        {
            deleteGuide(GuideIndex);
            GuideIndex++;
            ShowGuide(GuideIndex);
        }
    }
    private void GuideInit()
    {
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
