using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public GameObject RedBird;
    public GameObject RedBirdAft;
    public GameObject RedBirdAngry;
    public GameObject Egg;
    public GameObject Enemies;

    private void Awake()
    {
        RedBirdAft.SetActive(false);
        RedBirdAngry.SetActive(false);
    }
    private void Start()
    {
        Invoke("ShowRedBirdAft", 5.8f);
        Invoke("ShowRedBirdAngry", 7.5f);
        Invoke("LoadStartScene", 10f);
    }

    private void ShowRedBirdAft()
    {
        Egg.SetActive(false);
        RedBird.SetActive(false);
        RedBirdAft.SetActive(true);
    }

    private void ShowRedBirdAngry()
    {
        RedBirdAft.SetActive(false);
        RedBirdAngry.SetActive(true);
    }

    private void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
