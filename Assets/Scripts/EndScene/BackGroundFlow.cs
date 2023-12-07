using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundFlow : MonoBehaviour
{
    public float scrollSpeed = 2f;

    public Transform[] transforms;

    // scrollSpeed는 화면이 흐르는 속도입니다.
    // 아래에서 new Vector2(-moveX, 0)으로 한 이유는
    // 캐릭터가 오른쪽으로 이동하는 느낌을 받도록
    // 화면이 왼쪽에서 오른쪽으로 이동하게 만든 것입니다.

    private void Update()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            float moveX = Time.deltaTime * scrollSpeed;
            transforms[i].Translate(new Vector2(-moveX, 0));

            if (transforms[i].position.x < -17.28f)
                transforms[i].position = new Vector2(15.4f, 0);
        }
        
    }
}
