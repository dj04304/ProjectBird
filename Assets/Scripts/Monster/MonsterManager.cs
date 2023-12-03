using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
   
    public GameObject[] prefabs;

    private List<GameObject>[] monstersList;


    private void Awake()
    {
        monstersList = new List<GameObject>[prefabs.Length];

        // List 초기화
        for(int i = 0; i < monstersList.Length; i++)
        {
            monstersList[i] = new List<GameObject>(); 
        }

    }

    public GameObject GetMonster(int index, Transform transform)
    {
        GameObject select = null;

        // 비활성화된 오브젝트가 있다면 게임오브젝트에 접근하여 true값을 준다.
        foreach (GameObject objs in monstersList[index])
        {
            if (!objs.activeSelf)
            {
                select = objs;
                select.SetActive(true);
                break;
            }
        }

        // null값이 들어온다면 새로이 생성하고 select에 할당
        if (select == null) 
        {
            // Instantiate -> 복제하여 생성하는 함수 , transform -> 하이어라키창을 관리하기 위해 넣어줌
            select = Instantiate(prefabs[index], transform);

            OwlMonster owlComponent = select.GetComponent<OwlMonster>();
           
            if(prefabs[index].name == "Owl")
            {
                owlComponent.SetOwlHealth(2);
                owlComponent.SetOwlScore(400);
            }
            else
            {
                Monster monsterComponent = select.GetComponent<Monster>();
                monsterComponent.health = 1;
                monsterComponent.score = 100;
            }
            // 배열의 첫 번째 몬스터가 "Owl"이라고 가정하고 체력을 2로 설정
                
            //Debug.Log("부엉이 체력: " + monsterComponent.health);
            //Debug.Log("??" + monsterComponent.health);
            //Debug.Log("???: " + monsterComponent.health);


            //monstersList에 select 추가해줌
            monstersList[index].Add(select);
        }

        return select;
    }

}
