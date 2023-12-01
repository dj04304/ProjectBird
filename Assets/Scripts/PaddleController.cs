using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x, 0) * speed * Time.deltaTime;
    }
}
