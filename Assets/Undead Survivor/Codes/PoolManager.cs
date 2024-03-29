using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolManager : MonoBehaviour
{
    // ��������� ������ ����
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ���� �ʿ��� / �������� 2����� ����Ʈ�� 2���� �ʿ���
    List<GameObject>[] pools;
    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        //�ʱ�ȭ
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        Debug.Log(pools.Length);
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ������ Ǯ�� ����ִ�(��Ȱ��ȭ ��) ���ӿ�����Ʈ ����
        // �߰��ϸ� select������ �Ҵ�

        foreach (GameObject item in pools[index])
        {
            if (item.activeSelf == false)
            {
                // �߰��ϸ� select ������ �Ҵ� ��Ȱ��ȭ ������Ʈ�� ã���� SetActive �Լ��� Ȱ��ȭ
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ��ã����? -> ���Ӱ� �����ϰ� select ������ �Ҵ�
        if(select == null)
        {
            // Instantiate : ���� ������Ʈ�� �����Ͽ� ��鿡 �����ϴ� �Լ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }

}
