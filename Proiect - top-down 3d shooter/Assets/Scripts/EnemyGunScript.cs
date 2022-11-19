using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;              //bullet firing point

    [SerializeField]
    GameObject projectilePrefab;        //bullet prefab

    [SerializeField]
    [Range(1f, 10f)]
    float firingSpeed;

    public static EnemyGunScript Instance;   //GunScript object instance
    float lastTimeShot = 0;             //last time the player shot with the gun
    GameObject _parent;                 //gameobject where all the generated bullets will be placed as childs

    void Awake()
    {
        Instance = GetComponent<EnemyGunScript>();
    }

    void Start()
    {
        _parent = GameObject.Find("Bullets");
    }

    public void Shoot()
    {
        //Minimum time between two shots will be 1/firingSpeed seconds
        if (lastTimeShot + 1 / firingSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            //A new bullet will be generated and fired
            GameObject bullet = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            bullet.transform.parent = _parent.transform;
        }
    }
}