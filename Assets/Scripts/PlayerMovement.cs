using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 30f;
    public float jumpForce = 1f;
    public Rigidbody body;
    private float direction = 0f;
    private float jump = 0f;
    private Vector3 movementVector;

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        
        if (Mathf.Abs(direction) < 0.01f)
        {
            direction = 0f;
        }

        if(Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector3.up * jumpForce * 1000f * Time.deltaTime);
        }

        movementVector = new Vector3(direction * playerSpeed  * Time.deltaTime, 0, 0);

        transform.Translate(movementVector);
    }

}
