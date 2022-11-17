using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed;  //viteza cu care se deplaseaza glontul

    void Update()
    {
        MoveProjectile();
    }

    //functie cu care se face deplasarea gloantelor
    void MoveProjectile()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        //glontul o sa dispara in momentul in care atinge un zid sau cade pe mapa
        if (collision.gameObject.CompareTag("Bounds") || collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
