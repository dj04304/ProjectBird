using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBallScript : MonoBehaviour
{
    const float C_Radian = 180f;
    public Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        Vector3 movePos = pos + transform.up * speed * Time.deltaTime;
        rb.MovePosition(movePos); // 오브젝트에 적용된 rigidbody 2D에 시간마다 일정 속도로 좌표를 움직도록 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopWall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = C_Radian - tmp.z;
            transform.eulerAngles = tmp;
        }

        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }

        else if (collision.collider.CompareTag("Monster"))
        {
            Vector3 tmp = transform.eulerAngles;
            int r = Random.Range(0, 2);

            if (r == 0) tmp.z = C_Radian - tmp.z;
            else tmp.z = (C_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;
            //collision.gameObject.SetActive(false);
            //Debug.Log(collision.gameObject);
        }
    }
    //public float speed;
    //private Vector2 ballDirection;
    //public Rigidbody2D rigidbody;

    //void Start()
    //{
    //    rigidbody = GetComponent<Rigidbody2D>();
    //    Launch();

    //}

    //private void Launch()
    //{
    //    float x = 3f;
    //    float y = 3f;

    //    rigidbody.velocity = new Vector2(x * speed, y * speed);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("wall"))
    //    {
    //        ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);

    //    }
    //    else if (collision.gameObject.CompareTag("Paddle"))
    //    {
    //        float hitPoint = collision.contacts[0].point.x;
    //        float paddleCenter = collision.transform.position.x;

    //        float angle = (hitPoint - paddleCenter) * 3.0f;
    //        ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
    //    }
    //    else if (collision.gameObject.CompareTag("Monster"))
    //    {
    //        ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);

    //    }

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            Debug.Log("값");
        }
     }

    //public void Reset()
    //{
    //    rigidbody.velocity = Vector2.zero;
    //    transform.position = Vector2.zero;
    //    Launch();
    //}
}
