using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 30f;
    public Rigidbody body; 
    private float direction = 0f;
    private Vector3 movementVector;

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Mathf.Abs(direction) < 0.01f)
        {
            direction = 0f;
        }

        movementVector = new Vector3(direction * playerSpeed * Time.deltaTime, 0,0);

        transform.Translate(movementVector);
    }
}
