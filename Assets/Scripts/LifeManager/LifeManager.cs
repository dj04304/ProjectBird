using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private int _lifeCount;
    private int _maxLifeCount = 10;

    public int life
    {
        get { return _lifeCount; }
        set
        {
            if (value <= _maxLifeCount)
            {
                _lifeCount = value;
            }
        }
    }

    public int maxLife
    {
        set { _maxLifeCount = value; }
    }

    public void Dead()
    {
        if(_lifeCount != 0)
        {
            _lifeCount--;
            Debug.Log("남은 생명의 수 : " + _lifeCount);
        }
        else if(_lifeCount == 0)
        {
            Debug.Log("게임 오버");
            GameManager.Instance.IsGameOver = true;
        }

    }

    public void SuddenDead()
    {
        _lifeCount = 0;
        Debug.Log("게임 오버");
        GameManager.Instance.IsGameOver = true;
    }
}
