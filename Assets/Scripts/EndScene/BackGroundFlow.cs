using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundFlow : MonoBehaviour
{
    public float scrollSpeed = 2f;

    private void Update()
    {
        float moveX = Time.deltaTime * scrollSpeed;
        transform.Translate(new Vector2(-moveX, 0));

        if (transform.position.x < -10f)
            transform.position = new Vector2(0, 0);
    }
}
