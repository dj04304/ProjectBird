using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBallScript : MonoBehaviour
{
    const float C_Radian = 180f;
    public Rigidbody2D rb;
    public float speed;
    private bool isBallInPlay = false;
    public Transform target;
    public LifeManager lifeManager;

    public Sprite redBird;
    public Sprite puppleBird;
    public Sprite blueBird;

    private SpriteRenderer spriteRenderer;
    //private SettingManager settingManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        lifeManager.life = 3;

        SwitchingBird();
    }

    private void Update()
    {
        // 공은 현재 패들과 같이 따라가기 때문에(rigidbody가 kinematic으로 설정) 스스로 이동하기 위해 body type을 바꿔줘야 한다
        if (Input.GetButtonDown("Jump") && !isBallInPlay) 
        {
            rb.bodyType = RigidbodyType2D.Dynamic;  // rigidbody의 body type을 바꾼다
            isBallInPlay = true;            // 공이 자동으로 움직이는 상태를 판정하는 bool 값을 바꾼다
        }
    }

    private void FixedUpdate()
    {
        if (isBallInPlay)
        {
            Vector3 pos = rb.position;
            Vector3 movePos = pos + transform.up * speed * Time.deltaTime;
            rb.MovePosition(movePos); // 오브젝트에 적용된 rigidbody 2D에 시간마다 일정 속도로 좌표를 움직도록 함
        }
        else if (!isBallInPlay)
        {
            Vector2 move = new Vector2(target.position.x, target.position.y + 0.28f); // 타겟이 되는 오브젝(패들)의 좌표값에 위치를 추가로 수정하는 식으로 함
            rb.MovePosition(move);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopWall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = C_Radian - tmp.z;
            transform.eulerAngles = tmp;

            SoundManager.Instance.playBounce();
        }

        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;

            SoundManager.Instance.playBounce();
        }

        else if (collision.collider.CompareTag("Monster"))
        {
            Vector3 tmp = transform.eulerAngles;
            int r = Random.Range(0, 2);

            if (r == 0) tmp.z = C_Radian - tmp.z;
            else tmp.z = (C_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            lifeManager.Dead();
            Invoke("Reset", 0.5f);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(target.position.x, -3.67f) ;
        isBallInPlay = false;
    }

    private void SwitchingBird()
    {

        int selectBird = PlayerPrefs.GetInt("BallSprite", 1);
        Debug.Log(selectBird);

        switch (selectBird)
        {
            case 1:
                spriteRenderer.sprite = redBird;
                break;
             case 2:
                spriteRenderer.sprite = puppleBird;
                break;
            case 3:
                spriteRenderer.sprite = blueBird;
                break;
        }
    }
}
