using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MonsterManager monsterManager; // 몬스터 매니저

    private void Awake()
    {
        Instance = this;
    }
}
