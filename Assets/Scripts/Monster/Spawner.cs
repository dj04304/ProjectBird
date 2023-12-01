using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
   
    // 몬스터의 시작점 = -2.5 , 몬스터의 간격 0.35, 끝점 2.5 
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private float spacing;

    [SerializeField] private float spawnY;
    [SerializeField] private float spawnTimer;

    private float timer;

    private float speed = 0.35f;
    

    private void Start()
    {
        Spawn(rows, columns, transform.position.y);
    }

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
            Spawn(1, 15, spawnY);
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
        GameObject monsters = GameManager.Instance.monsterManager.GetMonster(Random.Range(0, 5), transform);

        if (monsters != null)
        {
            float startX = -2.45f;

            Vector2 spawnPos = new Vector2(startX + col * spacing, y + row * spacing);
            monsters.transform.position = spawnPos;

        }
        else
        {
            Debug.Log("Monster 생성 실패");
        }

    }

   

}




