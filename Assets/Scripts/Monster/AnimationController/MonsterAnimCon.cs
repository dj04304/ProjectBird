using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimCon : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float loopTimer;

    private bool isRight = false;
    

    private void Start()
    {
        animator.SetBool("LoopIdle",isRight);
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        MonsterIdleLoop();
    }


    // IEnumerator 주로 반복문에서 사용되는 인터페이스, 보통 StartCoroutine과 함께 쓰이기 때문에 사용 일시중지하고 재개하기 위해 사용했다.
    private void MonsterIdleLoop()
    {

            loopTimer += Time.deltaTime;

            if (loopTimer > 2.5f)
            {
                animator.SetBool("LoopIdle", !isRight);
            }


            if (loopTimer > 5f)
            {
                loopTimer = 0f;
                 animator.SetBool("LoopIdle", isRight);
            }

    }
  
}
