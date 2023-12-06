using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SettingManager : MonoBehaviour
{
    public GameObject SettingCanvas;
    private int selectIndex = 0;
    public Image ShowBall;

    public Sprite[] Balls = new Sprite[] { };

    // Start is called before the first frame update
    void Start()
    {
        ShowBall.sprite = Balls[selectIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }

    //pr
    public void QuitGame()
    {

        Debug.Log("QuitGame Event");
        Application.Quit();
    }

    public void QuitSetting()
    {
        SoundManager.Instance.playButtonEffect();
        Debug.Log("QuitSetting Event");
        //Debug.Log(PlayerPrefs.GetFloat("EffectVolume"));
        //Debug.Log(PlayerPrefs.GetFloat("BGMVolume"));
        SettingCanvas.SetActive(false);
        
    }

    private void chanageBallSprite(int Ballindex)
    {
        ShowBall.sprite = Balls[Ballindex];
    }

    public void SelectBallLeft()
    {
        if(selectIndex == 0)
        {
            selectIndex = Balls.Length - 1;
        }
        else
        {
            selectIndex--;
        }
        PlayerPrefs.SetInt("BallSprite", selectIndex+1);
        chanageBallSprite(selectIndex);
    }

    public void SelectBallRight()
    {
        if (selectIndex == Balls.Length - 1)
        {
            selectIndex = 0;
        }
        else
        {
            selectIndex++;
        }
        PlayerPrefs.SetInt("BallSprite", selectIndex+1);
        PlayerPrefs.GetInt("BallSprite");
        chanageBallSprite(selectIndex);
    }


}
