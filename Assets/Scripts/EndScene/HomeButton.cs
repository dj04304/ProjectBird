using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    // Ŭ�� �� StartScene(Home)���� �̵��ϴ� Home ��ư�� ��ũ��Ʈ�Դϴ�.
    public void OnHomeBtnClick()
    {
        Debug.Log("Start Scene���� �̵��մϴ�");

        //SceneManager.LoadScene("StartScene");
    }
}
