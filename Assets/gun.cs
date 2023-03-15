using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float speed = 5f;


    public void ShootBullet()
    {
        GameObject cB = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rig = cB.GetComponent<Rigidbody>();
        rig.AddForce(spawnPoint.forward * speed, ForceMode.Impulse);
    }

}
