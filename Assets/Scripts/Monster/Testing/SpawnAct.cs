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
    // Ÿ�̸ӿ� ���� ����
    public virtual void SpawnRoutine()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0f;
            Spawn();
        }
    }

    // ���� ����
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

        //// Random.Range�� 1���� �����ϴ� ������ GetComponentsInChildren �� �ڱ��ڽ�(0) �� �����ϱ� ������ �̸� ���� �ڽ�(1) ���� �����ϱ� ����
        //monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

    public virtual void MonsterRandomSpawn(int row, int col)
    {
        GameObject monsters = GameManager.Instance.monsterManager.GetMonster(Random.Range(0, 5), transform);

        if (monsters != null)
        {
            float startX = -2.45f;

            // startX ��ġ���� ����, 
            Vector2 spawnPos = new Vector2(startX + col * spacing, transform.position.y + row * spacing);
            monsters.transform.position = spawnPos;

        }
        else
        {
            Debug.Log("Monster ���� ����");
        }

    }
}
