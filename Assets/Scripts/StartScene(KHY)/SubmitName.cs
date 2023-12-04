using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitName : MonoBehaviour
{
    public GameObject GetNameScreen;
    public GameObject GetNameWarning;
    public GameObject GetNameConfirm;
    public TMP_InputField GetName;
    private string PlayerName = null;
    // Start is called before the first frame update
    void Start()
    {
        GetNameInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveName()
    {
        PlayerName = GetName.text;
        if((PlayerName.Length > 8) || (PlayerName.Length < 3))
        {
            GetNameWarning.SetActive(true);
            //GetName.text()
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", PlayerName);
            Debug.Log("Name Save Complete!");
            GetNameWarning.SetActive(false);
            GetNameConfirm.SetActive(true);
        }
    }

    public void QuitNameScreen()
    {
        GetNameWarning.SetActive(false);
        GetNameScreen.SetActive(false);
        //test
        string temp = PlayerPrefs.GetString("PlayerName");
        Debug.Log(temp);
    }

    private void GetNameInit()
    {
        GetNameWarning.SetActive(false);
        GetNameConfirm.SetActive(false);
    }
}
