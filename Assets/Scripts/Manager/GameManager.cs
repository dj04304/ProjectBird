using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public MonsterManager monsterManager; // 몬스터 매니저
    public ScoreManager scoreManager; // 스코어 매니저

    private bool _isGameOver;
    private int _totalScore;

    /// <summary>
    /// 싱글톤
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // _instance가 null 이면 GameObject에 "GameManager" 라는 오브젝트를 생성
                GameObject gameManagerObject = new GameObject("GameManager");
                // _instance 에 GameManager 컴포넌트 추가
                _instance = gameManagerObject.AddComponent<GameManager>();
                // DontDestroyOnLoad로 GameManagerobject가 씬 변환시 Destroy되지 않게끔 설정
                DontDestroyOnLoad(gameManagerObject);
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 인스턴스가 중복되어 생성될 경우 파괴해준다.
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(_isGameOver)
        {

            // 퍼즈와 동일로직 -> PauseManager
            // 혹은 바로 씬 넘어가기
            Debug.Log("Gamemanger 게임 오버!");
            scoreManager.AddScore(_totalScore);
        }
    }

    public bool IsGameOver
    {
        get { return _isGameOver; }
        set {  _isGameOver = value; }
    }

    public int TotalScore
    {
        get { return _totalScore; }
        set { _totalScore = value; }
    }

}
