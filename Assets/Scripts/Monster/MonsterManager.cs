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

        // List �ʱ�ȭ
        for(int i = 0; i < monstersList.Length; i++)
        {
            monstersList[i] = new List<GameObject>(); 
        }

    }

    public GameObject GetMonster(int index, Transform transform)
    {
        GameObject select = null;

        // ��Ȱ��ȭ�� ������Ʈ�� �ִٸ� ���ӿ�����Ʈ�� �����Ͽ� true���� �ش�.
        foreach (GameObject objs in monstersList[index])
        {
            if (!objs.activeSelf)
            {
                select = objs;
                select.SetActive(true);
                break;
            }
        }

        // null���� ���´ٸ� ������ �����ϰ� select�� �Ҵ�
        if (select == null) 
        {
            // Instantiate -> �����Ͽ� �����ϴ� �Լ� , transform -> ���̾��Űâ�� �����ϱ� ���� �־���
            select = Instantiate(prefabs[index], transform);

            //monstersList�� select �߰�����
            monstersList[index].Add(select);
        }

        return select;
    }

}
