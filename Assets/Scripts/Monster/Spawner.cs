using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
   
    // ������ ������ = -2.5 , ������ ���� 0.35, ���� 2.5 
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

    // ���� �ð����� ������
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

    // ���ο� ���ο��� ��������
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

    // ���� ����
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
            Debug.Log("Monster ���� ����");
        }

    }

   

}




