using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // 클릭 시 게임이 종료되는 Quit 버튼의 스크립트입니다.
    // Application.Quit(); 은 에디터 상에서는 작동하지 않습니다.
    public void OnQuitBtnClick()
    {
        Application.Quit();
    }
}
