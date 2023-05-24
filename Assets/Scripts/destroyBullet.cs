using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{
    public GameObject bullet;

    public void onCollisionEnter (Collision col) {
        Destroy(bullet);
    }

}
