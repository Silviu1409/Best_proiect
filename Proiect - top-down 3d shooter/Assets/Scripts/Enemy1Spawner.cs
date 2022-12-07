using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Enemy1Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy1Prefab;

    // public float lifetime = 100000f; //if you don't shoot the enemy, it will autodestroy after a certain time
    
    public static Enemy1Spawner Instance;


    void Awake()
    {
        Instance = GetComponent<Enemy1Spawner>();
    }


    async void Start()
    {
        await Task.Delay(7000);
       
        Vector3 spawnPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)); 
        GameObject enemy = Instantiate(Enemy1Prefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<Canvas>().enabled = true;
        enemy.GetComponent<HealthBar>().fill.fillAmount = 1;
        // Destroy(enemy, lifetime);
    }

    void Update()
    {

    }
}