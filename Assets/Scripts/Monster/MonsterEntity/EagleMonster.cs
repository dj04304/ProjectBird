using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eagle 클래스: 체력 1, 점수 100, 범위 내 십자모양의 5줄 파괴
/// </summary>
public class EagleMonster : Monster
{
    [SerializeField] private float rayX;
    [SerializeField] private float rayY;

    public void SetEagleHealth(int newHealth)
    {
        health = newHealth;

    }

    public void SetEagleScore(int newScore)
    {
        score = newScore;

    }

    public override void DestroyedMonster()
    {
        base.DestroyedMonster();
        DeactivateMonstersInLine();
    }

    /// <summary>
    /// RayCast
    /// </summary>
    private void DeactivateMonstersInLine()
    {
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y); //현재 좌표

        // x 축 양의 방향으로 레이 쏘기
        RaycastHit2D[] hitsRight = Physics2D.RaycastAll(rayOrigin, Vector2.right, rayX, LayerMask.GetMask("Monster"));
        ProcessHits(hitsRight);

        // x 축 음의 방향으로 레이 쏘기
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(rayOrigin, Vector2.left, rayX, LayerMask.GetMask("Monster"));
        ProcessHits(hitsLeft);

        // y 축 양의 방향으로 레이 쏘기
        RaycastHit2D[] hitsUp = Physics2D.RaycastAll(rayOrigin, Vector2.up, rayY, LayerMask.GetMask("Monster"));
        ProcessHits(hitsUp);

        // y 축 음의 방향으로 레이 쏘기
        RaycastHit2D[] hitsDown = Physics2D.RaycastAll(rayOrigin, Vector2.down, rayY, LayerMask.GetMask("Monster"));
        ProcessHits(hitsDown);

        //// 두 배열 합치기
        //RaycastHit2D[] hits = new RaycastHit2D[hitsRight.Length + hitsLeft.Length];
        //hitsRight.CopyTo(hits, 0);
        //hitsLeft.CopyTo(hits, hitsRight.Length);

        //Debug.Log("x축: " + transform.position.x);
        //Debug.Log("y축: " + transform.position.y);

        //Debug.Log("hitRight: " + hitsLeft.Length);
        //Debug.Log("hitRight: " + hitsRight.Length);
        //Debug.Log("rayOrigin: " + rayOrigin);
        
    }

    private void ProcessHits(RaycastHit2D[] hits)
    {
        foreach (var hit in hits)
        {
           // 현재 충돌한 게임오브젝트와 충돌한 게임오브젝트가 같지 않고, 충돌한 객체가 Monster 컴포넌트를 가지고 있을 경우 실행된다. 
            if (hit.collider.gameObject != gameObject && hit.collider.TryGetComponent(out Monster monsterComponent))
            {
                // 몬스터를 비활성화합니다.
                monsterComponent.gameObject.SetActive(false);
                GameManager.Instance.scoreManager.AddScore(monsterComponent.score);
            }
        }
    }

}
