using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] [Range(1,20)] int PoolSize = 5;
    [SerializeField] [Range(1f,5f)] float SpawnTimer = 1f;

    GameObject[] Pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void PopulatePool()
    {
        Pool = new GameObject[PoolSize];

        for (int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = Instantiate(EnemyPrefab, transform);
            Pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < Pool.Length; i++)
        {
            if (Pool[i].activeInHierarchy==false)
            {
                Pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
}
