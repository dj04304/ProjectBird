using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    // 몬스터의 시작점 = -2.5
    [SerializeField] private int rows; // 몬스터의 세로
    [SerializeField] private int columns; // 몬스터의 가로

    [SerializeField] private float spacing; // 몬스터의 간격
    [SerializeField] private float speed; // 몬스터의 속도

    // 랜덤 스폰되는 위치
    [SerializeField] private float spawnY; // 스폰 위치
    [SerializeField] private float spawnTimer; //스폰 시간

    [SerializeField] private float owlProbability; // 부엉이 등장 확률
    [SerializeField] private float eagleProbability; // 독수리 등장 확률

    private float timer;
    
    private float ranProbability;

    
    // 시작시에 몬스터 배치
    private void Start()
    {
        Spawn(rows, columns, transform.position.y);
    }

    // 일정 시간마다 몬스터가 내려옴
    private void Update()
    {

        MonsterMoveDown();
    }

    // 일정 시간마다 내려옴
    private void MonsterMoveDown()
    {
        timer += Time.deltaTime;

        if (timer > spawnTimer)
        {
            timer = 0f;
            Spawn(1, columns, spawnY);
            transform.Translate(Vector2.down * speed);
        }
    }

    // 가로열 세로열에 랜덤생성
    private void Spawn(int rows, int columns, float y)
    {

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                MonsterRandomSpawn(row, col, y);
            }
        }

    }

    // 랜덤 스폰
    public void MonsterRandomSpawn(int row, int col, float y)
    {
        GameObject monsters;
        ranProbability = Random.Range(0, 100);

        //Debug.Log("랜덤 숫자" + ranProbability);
       
        // 부엉이가 나올 확률 10퍼
        if(ranProbability <= owlProbability)
        {
            monsters = GameManager.Instance.monsterManager.GetMonster(0, transform);
            //Debug.Log("부엉: " + monsters.name);
            //Debug.Log("확률: " + ranProbability);
        }
        // 독수리 확률
        else if (ranProbability > owlProbability && ranProbability <= eagleProbability)
        {
            monsters = GameManager.Instance.monsterManager.GetMonster(1, transform);
            //Debug.Log("독:" + monsters.name);
        }
        else if (ranProbability > owlProbability && ranProbability <= eagleProbability)
        {
            monsters = GameManager.Instance.monsterManager.GetMonster(2, transform);
            //Debug.Log("독:" + monsters.name);
        }
        else
        {
            monsters = GameManager.Instance.monsterManager.GetMonster(Random.Range(2, 6), transform);
            //Debug.Log("그냥 새: " + monsters.name);
        }


        if (monsters != null)
        {
            
            float startX = -2.45f;

            Vector2 spawnPos = new Vector2(startX + col * spacing, y + row * spacing);
            monsters.transform.position = spawnPos;

            //Debug.Log(transform.position);
            //Debug.Log("y축: " + y);
            //Debug.Log("transform: " + y + row * spacing);

        }
        else
        {
            Debug.Log("Monster 생성 실패");
        }

    }

   

}




