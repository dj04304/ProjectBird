using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLifeUI : MonoBehaviour
{
    private GameObject _currentLife;
    private int _life;

    public int CurrentLifeChange
    {
        get { return _life; }
        set
        {
            if (_life != value)
            {
                LifeImageToggle();
                
            }

            if (value < 10)
            {
                _life = value;
            }
            else
            {
                _life = 10;
                Debug.Log("최대 라이프는 10을 초과할 수 없습니다");
            }

            
        }
    }


    private void Awake()
    {
        _currentLife = gameObject;
        CurrentLifeChange += 2; // 임시로 UI 보여주기 위해 넣어준 라이프값, 라이프 변수 및 상호작용이 구축되면 제거함
        LifeImageToggle();
    }

    private void LifeImageToggle()
    {
        // 원래는 LifeImage를 필드에 저장해둬야 하는데 일단은 이대로 갑니다
        for (int i = 1; i <= _life; i++)
        {
            _currentLife.transform.Find("LifeImage" + i.ToString()).gameObject.SetActive(true);
        }
        for (int i = _life + 1; i <= 10; i++)
        {
            _currentLife.transform.Find("LifeImage" + i.ToString()).gameObject.SetActive(false);
        }
    }
}
