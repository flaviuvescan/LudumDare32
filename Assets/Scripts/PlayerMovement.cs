using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement instance;

    public LeanTweenType jumpEase = LeanTweenType.easeOutCirc;
    public float playerSpeed = 30f;
    public float jumpForce = 1f;
    public float gravity = -2f;
    public Rigidbody body;

    private float xDirection = 0f;
    private float yDirection = 0f;
    private float jump = 0f;
    private Vector3 movementVector;

    public enum PlayerState { onGround, inAir };
    public PlayerState state = PlayerState.onGround;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            state = PlayerState.inAir;
            LeanTween.moveLocalY(gameObject, transform.localPosition.y + jumpForce, 0.3f).setEase(jumpEase).setIgnoreTimeScale(true);
        }

        if (Mathf.Abs(xDirection) < 0.01f)
        {
            xDirection = 0f;
        }

        if (state == PlayerState.inAir)
        {
            yDirection = gravity;
        }
        else
        {
            yDirection = 0f;
        }

        movementVector = new Vector3(xDirection * playerSpeed, yDirection, 0) * Time.deltaTime / Time.timeScale;

        transform.Translate(movementVector);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ground") 
            || other.gameObject.tag.Equals("InvisibleBullet"))
        {
            state = PlayerState.onGround;
        }
    }
}
