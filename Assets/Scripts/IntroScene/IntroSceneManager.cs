using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public GameObject RedBird;
    public GameObject Egg;
    public GameObject Enemies;

    private void Update()
    {
        if (Enemies == null)
            Egg.SetActive(false);
    }
}
