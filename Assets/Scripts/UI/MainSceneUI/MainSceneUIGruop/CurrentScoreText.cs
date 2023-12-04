using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentScoreText : MonoBehaviour
{
    private TMP_Text _scoreText;
    private int _currentScore;

    private void Awake()
    {
        _scoreText = transform.Find("CurrentScore").GetComponent<TMP_Text>();
    }

    public int ChangeCurrentScore
    {
        get { return _currentScore; }
        set { 
            _currentScore = value;
            _scoreText.text = _currentScore.ToString();
        }
    }
}
