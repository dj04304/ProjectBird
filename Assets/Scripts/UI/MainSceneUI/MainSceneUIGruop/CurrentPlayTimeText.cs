using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentPlayTimeText : MonoBehaviour
{
    private TMP_Text _timeText;
    private float _currentTime;

    private void Awake()
    {
        _timeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentTime += Time.deltaTime;
        _timeText.text = "진행 시간\n" + _currentTime.ToString("N1");
    }
}
