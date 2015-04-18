using UnityEngine;
using System.Collections;

public class ShootingManager : MonoBehaviour {

    public GameObject bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            bulletClone.transform.localRotation = transform.parent.localRotation;
        }
    }
}
