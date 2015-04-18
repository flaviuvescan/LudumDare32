using UnityEngine;
using System.Collections;

public class ShootingManager : MonoBehaviour {

    public GameObject bullet;
    public GameObject invisibleBullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            bulletClone.transform.localRotation = transform.parent.localRotation;

            GameObject invisibleBulletClone = Instantiate(invisibleBullet, transform.position, Quaternion.identity) as GameObject;
            invisibleBulletClone.transform.localRotation = transform.parent.localRotation;

            bulletClone.GetComponent<BulletBehaviour>().invisibleBullet = invisibleBulletClone;
        }
    }
}
