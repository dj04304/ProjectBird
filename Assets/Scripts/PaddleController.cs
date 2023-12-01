using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    public Rigidbody2D rb;
    private float x = 0;

    private Vector3 paddlePosition;

    void Start()
    {
        paddlePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        paddlePosition.x += x * speed * Time.deltaTime;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, -2.3f, 2.3f); // 패들의 이동 범위
        transform.position = paddlePosition;
    }
}
