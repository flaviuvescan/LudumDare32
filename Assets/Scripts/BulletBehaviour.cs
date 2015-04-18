using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float bulletSpeed = 15f;
    private Vector3 directionVector = new Vector3(1, 0, 0);

    void Update()
    {
        transform.Translate(directionVector * bulletSpeed * Time.deltaTime);
    }
}
