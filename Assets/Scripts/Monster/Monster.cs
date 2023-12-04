using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IMonster
{
    private int _health;
    private int _score;

    private void DestroyedMonster()
    {
        if (_health <= 0)
        {
            // 몬스터 파괴
            gameObject.SetActive(false);

        }
    }


    // 공에 닿았을 때 몬스터 파괴
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _health--;

            //Debug.Log("MonsterHealth: " + _health);

            DestroyedMonster();

            Debug.Log("asdsad" + _score);

            GameManager.Instance.scoreManager.AddScore(_score);

        }

    }

    public int health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int score
    {
        get { return _score; }
        set { _score = value; }
    }

}
