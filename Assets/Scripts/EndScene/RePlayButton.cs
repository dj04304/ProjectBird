using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlayButton : MonoBehaviour
{
    // 클릭 시 MainScene으로 이동하는 Replay 버튼의 스크립트입니다.
    public void OnReplayBtnClick()
    {
        Debug.Log("Main Scene으로 이동합니다");

        //SceneManager.LoadScene("MainScene");
    }
}
