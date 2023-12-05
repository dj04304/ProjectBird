using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private int _lifeCount;

    public int life
    {
        get { return _lifeCount; }
        private set { _lifeCount = value; }
    }

    public void Dead()
    {
        if(_lifeCount != -1)
        {
            _lifeCount--;
        }
        Debug.Log("남은 생명의 수 : " + _lifeCount);
    }

    public void SuddenDead()
    {
        _lifeCount = 0;
        Debug.Log("게임 오버");
    }
}
