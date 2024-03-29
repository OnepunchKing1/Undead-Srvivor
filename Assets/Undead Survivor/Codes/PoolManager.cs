using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolManager : MonoBehaviour
{
    // 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들이 필요함 / 프리펩이 2개라면 리스트도 2개가 필요함
    List<GameObject>[] pools;
    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        //초기화
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        Debug.Log(pools.Length);
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택한 풀의 놀고있는(비활성화 된) 게임오브젝트 접근
        // 발견하면 select변수에 할당

        foreach (GameObject item in pools[index])
        {
            if (item.activeSelf == false)
            {
                // 발견하면 select 변수에 할당 비활성화 오브젝트를 찾으면 SetActive 함수로 활성화
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못찾으면? -> 새롭게 생성하고 select 변수에 할당
        if(select == null)
        {
            // Instantiate : 원본 오브젝트를 복제하여 장면에 생성하는 함수
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }

}
