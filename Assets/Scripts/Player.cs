using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float climbingSpeed = 5f;
    [SerializeField] private float jumpSpeed = 8f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private Collider2D myCollider;

    private float gravityScaleAtStart;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHorizontalSpeed);
    }
    private void Jump()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                myRigidbody.velocity += jumpVelocityToAdd;
            }
        }
    }
    private void ClimbLadder()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = 0f;
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbingSpeed);
            myRigidbody.velocity = climbVelocity;
            bool playerVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Climbing", playerVerticalSpeed);
        }
        else
        {
            myAnimator.SetBool("Climbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
        }
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            this.transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
