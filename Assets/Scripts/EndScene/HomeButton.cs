using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    // 클릭 시 StartScene(Home)으로 이동하는 Home 버튼의 스크립트입니다.
    public void OnHomeBtnClick()
    {
        Debug.Log("Start Scene으로 이동합니다");

        //SceneManager.LoadScene("StartScene");
    }
}
