using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBallScript : MonoBehaviour
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
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.velocity = new Vector2(x * speed, y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ballDirection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {

            float hitPoint = collision.contacts[0].point.x;
            float paddleCenter = collision.transform.position.x;
            float angle = (hitPoint - paddleCenter) * 2.0f;
            ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
        }

    }
    //public void Reset()
    //{
    //    rigidbody.velocity = Vector2.zero;
    //    transform.position = Vector2.zero;
    //    Launch();
    //}
}
