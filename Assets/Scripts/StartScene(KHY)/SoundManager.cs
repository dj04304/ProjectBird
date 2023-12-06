using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bounce;
    public AudioSource monsterDeath;
    public AudioSource drop;
    public AudioSource gameOver;
    public AudioSource buttonEffect;
    public AudioSource bgm;


    public float BGMVolume = 70;
    public float EffectVolume = 70;
    // Start is called before the first frame update

    private static SoundManager _instance;
    void Start()
    {
        bgm.volume = (float)0.07;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"BGMVolume : {BGMVolume}");
        //Debug.Log($"EffectVolume : {EffectVolume}");
    }

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject SoundManagerObject = new GameObject("SoundManager");
                // _instance 에 GameManager 컴포넌트 추가
                _instance = SoundManagerObject.AddComponent<SoundManager>();
                // DontDestroyOnLoad로 GameManagerobject가 씬 변환시 Destroy되지 않게끔 설정
                DontDestroyOnLoad(SoundManagerObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (null == _instance)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void playBounce()
    {
        bounce.volume = EffectVolume;
        bounce.Play();
    }

    public void playMonsterDeath()
    {
        monsterDeath.volume = EffectVolume;
        monsterDeath.Play();
    }

    public void playDrop()
    {
        drop.volume = EffectVolume;
        drop.Play();
    }

    public void playGameOver()
    {
        gameOver.volume = EffectVolume;
        gameOver.Play();
    }

    public void playButtonEffect()
    {
        buttonEffect.volume = EffectVolume;
        buttonEffect.Play();
    }

    public void SetBGMVolume(float inputVolume)
    {
        bgm.volume = inputVolume/10;
    }

}
