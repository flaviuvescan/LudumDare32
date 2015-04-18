using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

    public BulletBehaviour bulletBehaviour;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            bulletBehaviour.DestroyBullet();
        }
    }
}
