using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLifeUI : MonoBehaviour
{
    private GameObject _currentLife;
    private int _life;
    private int _maxLife = 10;

    private Dictionary<int, GameObject> _lifeImageObject = new Dictionary<int, GameObject>();

    private string animationsBool = "Broken";

    public int CurrentLifeChange
    {
        get { return _life; }
        set
        {
            if (_life != value)
            {
                LifeImageToggle(_life, value);
                //Debug.Log(_life);
                
            }

            if (value < _maxLife)
            {
                _life = value;
            }
            else
            {
                _life = _maxLife;
                //Debug.Log($"최대 라이프는 {_maxLife}을 초과할 수 없습니다");
            }

            
        }
    }

    public int SetMaxLifeCount
    {
        set 
        {
            if (_maxLife != value)
            {
                _maxLife = value;
            }
        }
    }

    private void Awake()
    {
        _currentLife = gameObject;    

        for (int i = 1; i <= _maxLife; i++)
        {
            _lifeImageObject.Add(i, _currentLife.transform.Find("LifeImage" + i.ToString()).gameObject);
        }
    }

    private void LifeImageToggle(int currentlife, int newlife)
    {
        int difference = newlife - currentlife;

        if (difference > 0)
        {
            for (int i = currentlife; i < newlife; i++)
            {
                _lifeImageObject.TryGetValue(i+1, out GameObject lifeImage);
                lifeImage.SetActive(true);
                lifeImage.GetComponent<Animator>().SetBool(animationsBool, false);
            }
        }
        else
        {
            for (int i = currentlife; i > newlife && i > 0; i--)
            {
                _lifeImageObject.TryGetValue(i, out GameObject lifeImage);
                lifeImage.GetComponent<Animator>().SetBool(animationsBool, true);
            }
        }
    }
}
