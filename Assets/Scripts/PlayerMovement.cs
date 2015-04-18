using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 30f;
    public float jumpForce = 1f;
    public float yMovement = 0f;
    public float gravity = 60f;
    public Rigidbody body;

    private float direction = 0f;
    private float jump = 0f;
    private Vector3 movementVector;
    private bool canCheckLand = false;

    public enum PlayerState { onGround, inAir };
    public PlayerState state = PlayerState.onGround;

    void Start()
    {
        yMovement = 0f;
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        
        if (Mathf.Abs(direction) < 0.01f)
        {
            direction = 0f;
        }

        if (Input.GetButtonDown("Jump") && state == PlayerState.onGround)
        {
            state = PlayerState.inAir;

            yMovement = jumpForce;

            StartCoroutine("CheckForLand");
        }
        else
        {
            yMovement -= gravity * Time.deltaTime;
        }

        movementVector = new Vector3(direction * playerSpeed * Time.deltaTime / Time.timeScale, yMovement, 0);

        transform.Translate(movementVector);

        if (Mathf.Abs(body.velocity.y) < 0.1f
            && state == PlayerState.inAir
            && canCheckLand == true)
        {
            state = PlayerState.onGround;
            yMovement = 0f;
        }
    }

    IEnumerator CheckForLand()
    {
        canCheckLand = false;
        yield return new WaitForSeconds(0.1f);
        canCheckLand = true;
    }
}
