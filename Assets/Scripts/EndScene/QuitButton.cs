using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Ŭ�� �� ������ ����Ǵ� Quit ��ư�� ��ũ��Ʈ�Դϴ�.
    // Application.Quit(); �� ������ �󿡼��� �۵����� �ʽ��ϴ�.
    public void OnQuitBtnClick()
    {
        Application.Quit();
    }
}
