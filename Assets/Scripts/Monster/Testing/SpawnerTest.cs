using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerTest : SpawnAct
{
    [SerializeField] private Spawner monsterStartDeploy;
    private Transform monsterStatDeployTrans;

    // ������ ������ = -2.5 , ������ ���� 0.35, ���� 2.5 
    [SerializeField] private int spawnRows;
    [SerializeField] private int spawnColumns;
    [SerializeField] private float spawnSpacing;

    private float SpawnTimer;

    private void Start()
    {
        //monsterStatDeployTrans = monsterStartDeploy.GetCurrentTransform();
        rows = spawnRows;
        columns = spawnColumns;
        spacing = spawnSpacing;
        timer = SpawnTimer;
    }

    private void Update()
    {
        SpawnRoutine();
    }

    // ���� ���� �ð�
    public override void SpawnRoutine()
    {
       base.SpawnRoutine();
    }

    // ���� ����
    public override void Spawn()
    {
       base.Spawn();
    }

    public override void MonsterRandomSpawn(int row, int col)
    {
        base.MonsterRandomSpawn(row, col);

        GameObject monsters = GameManager.Instance.monsterManager.GetMonster(Random.Range(0, 5), monsterStatDeployTrans);
    }




}

