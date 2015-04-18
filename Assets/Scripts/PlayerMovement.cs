using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 30f;
    public float jumpForce = 1f;
    public Rigidbody body;

    private float direction = 0f;
    private float jump = 0f;
    private Vector3 movementVector;
    private bool canCheckLand = false;

    public enum PlayerState { onGround, inAir };
    public PlayerState state = PlayerState.onGround;

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        
        if (Mathf.Abs(direction) < 0.01f)
        {
            direction = 0f;
        }

        if(Input.GetButtonDown("Jump") && state == PlayerState.onGround)
        {
            state = PlayerState.inAir;
            body.AddForce(Vector3.up * jumpForce * 1000f * Time.deltaTime );
            StartCoroutine("CheckForLand");
        }

        movementVector = new Vector3((direction * playerSpeed * Time.deltaTime) / Time.timeScale, 0, 0);

        transform.Translate(movementVector);

        if (Mathf.Abs(body.velocity.y) < 0.1f
            && state == PlayerState.inAir
            && canCheckLand == true)
        {
            state = PlayerState.onGround;
            CameraShake.instance.ShakeCamera();
        }
    }

    IEnumerator CheckForLand()
    {
        canCheckLand = false;
        yield return new WaitForSeconds(0.1f);
        canCheckLand = true;
    }
}
