using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnAct : MonoBehaviour
{
    protected int rows;
    protected int columns;
    protected float spacing;

    protected float timer;
    // 타이머에 따른 로직
    public virtual void SpawnRoutine()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0f;
            Spawn();
        }
    }

    // 몬스터 생성
    public virtual void Spawn()
    {

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                MonsterRandomSpawn(row, col);
            }
        }
        //GameObject monster = GameManager.Instance.monsterManager.GetMonster(Random.Range(0, 5));

        //// Random.Range를 1부터 시작하는 이유는 GetComponentsInChildren 가 자기자신(0) 도 포함하기 때문에 이를 빼고 자식(1) 부터 시작하기 위함
        //monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

    public virtual void MonsterRandomSpawn(int row, int col)
    {
        GameObject monsters = GameManager.Instance.monsterManager.GetMonster(Random.Range(0, 5), transform);

        if (monsters != null)
        {
            float startX = -2.45f;

            // startX 위치에서 시작, 
            Vector2 spawnPos = new Vector2(startX + col * spacing, transform.position.y + row * spacing);
            monsters.transform.position = spawnPos;

        }
        else
        {
            Debug.Log("Monster 생성 실패");
        }

    }
}
