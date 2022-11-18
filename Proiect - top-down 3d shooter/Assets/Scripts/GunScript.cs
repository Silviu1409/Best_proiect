using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;              //punctul din care pleaca glontul

    [SerializeField]
    GameObject projectilePrefab;        //prefab-ul glontului

    [SerializeField]
    [Range(1f, 10f)]
    float firingSpeed;                  //perioada la care playerul poate trage cu arma

    public static GunScript Instance;   //instanta a unui obiect de tip GunScript
    float lastTimeShot = 0;             //timpul la care playerul a tras ultima data cu arma in joc
    GameObject _parent;                 //gameobject in care toate clonele ale gloantelor generate sa fie puse ca child

    void Awake()
    {
        Instance = GetComponent<GunScript>();
    }

    void Start()
    {
        _parent = GameObject.Find("Bullets");
    }

    public void Shoot()
    {
        //firing rate-ul minim va fi 1/firingSpeed secunde
        if (lastTimeShot + 1 / firingSpeed <= Time.time && PlayerScript.noOfBulletsInRound > 0)
        {
            PlayerScript.noOfBulletsInRound -= 1;

            lastTimeShot = Time.time;
            //se va genera un glont nou
            GameObject bullet = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            bullet.transform.parent = _parent.transform;
        }
    }
}