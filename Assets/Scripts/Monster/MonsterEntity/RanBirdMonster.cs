using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RanBirdMonster : Monster
{
    public void SetRanMonHealth(int newHealth)
    {
        health = newHealth;

    }

    public void SetRanMonScore(int newScore)
    {
        score = newScore;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            health--;
            //Debug.Log("작동!!");

            string collidedObjectName = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            //Debug.Log(gameObject.name);

            GameObject[] objectsWithSameName = GameObject.FindGameObjectsWithTag("Monster");

            //Debug.Log("알려줘: " + collidedObjectName);
            //Debug.Log("Monster Tag" + objectsWithSameName.Length);


            foreach (GameObject obj in objectsWithSameName)
            {
                if (obj.name == collidedObjectName + "(Clone)")
                {
                    Debug.Log("알려줘2: " + obj.name); // ranobj
                    Debug.Log("랜덤몬스터라고!" + collidedObjectName);
                    obj.SetActive(false);

                    if (obj.name == "Owl(Clone)")
                    {
                        score += 200;

                    }
                    else
                    {
                        score += 100;
                    }

                }

            }


            Debug.Log("점수는?: " + score);

            DestroyedMonster();
        }
       
    }

    public override void DestroyedMonster()
    {
        base.DestroyedMonster();
    }

}
