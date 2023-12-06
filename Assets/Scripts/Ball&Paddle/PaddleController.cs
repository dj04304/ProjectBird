using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float horizontal;
    public float speed = 2.5f;
    public float[] arrAngles = { -75, -60, -45, -30, -15, 0, 15, 30, 45, 60, 75 }; // 임의의 각도값

    void Start()
    {

    }

    // rigidbody 2D를 사용하기 위한 코드 수정
    void FixedUpdate()
    {
        OnMove();
    }

    public void OnMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        transform.Translate(move * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            int r = Random.Range(0, arrAngles.Length);
            Vector3 tmp = collision.transform.eulerAngles;
            tmp.z = arrAngles[r];
            collision.transform.eulerAngles = tmp;
        }
    }
}
