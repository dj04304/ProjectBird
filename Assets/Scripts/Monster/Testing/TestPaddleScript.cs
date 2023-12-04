using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPaddleScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    public float speed = 2.5f;
    public float[] arrAngles = { -75, -60, -45, -30, -15, 0, 15, 30, 45, 60, 75 };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // rigidbody 2D를 사용하기 위한 코드 수정
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 pos = rb.position;
        Vector2 movePos = pos + (move * speed * Time.deltaTime);
        rb.MovePosition(movePos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            int r = Random.Range(0, arrAngles.Length);
            Vector3 tmp = collision.transform.eulerAngles;
            tmp.z = arrAngles[r];
            collision.transform.eulerAngles = tmp;
        }
    }
    //[SerializeField] private float speed = 2.5f;
    //public Rigidbody2D rb;
    //private float x = 0;

    //private Vector3 paddlePosition;

    //void Start()
    //{
    //    paddlePosition = transform.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    x = Input.GetAxisRaw("Horizontal");
    //}

    //private void FixedUpdate()
    //{
    //    OnMove();
    //}

    //private void OnMove()
    //{
    //    paddlePosition.x += x * speed * Time.deltaTime;
    //    paddlePosition.x = Mathf.Clamp(paddlePosition.x, -2.3f, 2.3f); // 패들의 이동 범위
    //    transform.position = paddlePosition;
    //}
}
