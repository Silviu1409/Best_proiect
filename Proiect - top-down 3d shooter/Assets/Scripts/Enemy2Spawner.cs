using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Enemy2Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy2Prefab;
    
    public static Enemy2Spawner Instance;
    void Awake()
    {
        Instance = GetComponent<Enemy2Spawner>();
    }


    async void Start()
    {
        await Task.Delay(7000);

        Vector3 spawnPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)); 
        GameObject enemy = Instantiate(Enemy2Prefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<HealthBar>().fill.fillAmount = 1;
        enemy.GetComponent<Canvas>().enabled = true;

    }

    void Update()
    {

    }
}