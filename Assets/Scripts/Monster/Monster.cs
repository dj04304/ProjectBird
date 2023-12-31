using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IMonster
{
    private int _health;
    private int _score;

    public virtual void DestroyedMonster()
    {
        if (_health <= 0)
        {
            //Debug.Log("몬스터 헬스: " + _health);
            // 몬스터 파괴
            gameObject.SetActive(false);
            GameManager.Instance.scoreManager.AddScore(_score);
            SoundManager.Instance.playMonsterDeath(); // 몬스터 죽을때 나는 소리
            //Debug.Log("_score" + _score);
        }
    }


    // 공에 닿았을 때 몬스터 파괴
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _health--;
            Debug.Log("몬스터 헬스: " + _health);
            //Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite);

            DestroyedMonster();

        }

    }

    // monster가 deadLine까지 넘어올 경우 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("death"))
        {
            GameManager.Instance.IsGameOver = true;
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
