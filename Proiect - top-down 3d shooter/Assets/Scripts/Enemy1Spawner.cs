using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Enemy1Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy1Prefab;
    
    async void Start()
    {
        await Task.Delay(7000);

        Vector3 spawnPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)); 
        Instantiate(Enemy1Prefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {

    }
}
