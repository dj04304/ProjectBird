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


    // IEnumerator �ַ� �ݺ������� ���Ǵ� �������̽�, ���� StartCoroutine�� �Բ� ���̱� ������ ��� �Ͻ������ϰ� �簳�ϱ� ���� ����ߴ�.
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
