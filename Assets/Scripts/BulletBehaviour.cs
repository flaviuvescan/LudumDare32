using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float bulletSpeed = 15f;
    public GameObject invisibleBullet;
    private Vector3 directionVector = new Vector3(1, 0, 0);

    void OnEnable()
    {
        StartCoroutine("SelfDestructBullet");
    }

    void Update()
    {
        transform.Translate(directionVector * bulletSpeed * Time.deltaTime);
    }

    IEnumerator SelfDestructBullet()
    {
        yield return new WaitForSeconds(10);
        DestroyBullet();
    }

    public void DestroyBullet()
    {
        if (invisibleBullet != null)
        {
            Destroy(invisibleBullet);
        }

        Destroy(gameObject);
    }
}
