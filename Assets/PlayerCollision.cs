using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player") && TimeManager.instance.nonPlayerTime == 1)
        {
            Application.LoadLevel(0);
        }
    }
}
