using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TestBallScript : MonoBehaviour
{
    public float speed;
    private Vector2 ballDirection;
    public Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Launch();

    }

    private void Launch()
    {
        float x = 3f;
        float y = 3f;

        rigidbody.velocity = new Vector2(x * speed, y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);

        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitPoint = collision.contacts[0].point.x;
            float paddleCenter = collision.transform.position.x;

            float angle = (hitPoint - paddleCenter) * 3.0f;
            ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
        }
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            // 여기에 목숨 까이는 로직 필요
            GameManager.Instance.IsGameOver = true;
            Debug.Log("데드라인 넘어감");
        }
    }
   
}
