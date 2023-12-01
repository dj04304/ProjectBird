using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLifeUI : MonoBehaviour
{
    private GameObject _currentLife;
    private int _life;

    public int CurrentLifeChange
    {
        get { return _life; }
        set
        {
            if (_life != value)
            {
                LifeImageToggle();
                
            }

            if (value < 10)
            {
                _life = value;
            }
            else
            {
                _life = 10;
                Debug.Log("�ִ� �������� 10�� �ʰ��� �� �����ϴ�");
            }

            
        }
    }


    private void Awake()
    {
        _currentLife = gameObject;
        CurrentLifeChange += 2; // �ӽ÷� UI �����ֱ� ���� �־��� ��������, ������ ���� �� ��ȣ�ۿ��� ����Ǹ� ������
        LifeImageToggle();
    }

    private void LifeImageToggle()
    {
        // ������ LifeImage�� �ʵ忡 �����ص־� �ϴµ� �ϴ��� �̴�� ���ϴ�
        for (int i = 1; i <= _life; i++)
        {
            _currentLife.transform.Find("LifeImage" + i.ToString()).gameObject.SetActive(true);
        }
        for (int i = _life + 1; i <= 10; i++)
        {
            _currentLife.transform.Find("LifeImage" + i.ToString()).gameObject.SetActive(false);
        }
    }
}
