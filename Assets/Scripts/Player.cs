using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float runSpeed = 0.1f;
    [SerializeField] private float jumpSpeed = 8f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Jump();
        // FlipSprite();
    }

    private void Run()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            myAnimator.SetBool("Running", true);
            this.transform.position = new Vector3(this.transform.position.x - runSpeed, this.transform.position.y, this.transform.position.z);
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myAnimator.SetBool("Running", true);
            this.transform.position = new Vector3(this.transform.position.x + runSpeed, this.transform.position.y, this.transform.position.z);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
    }
    private void Jump() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + jumpSpeed, this.transform.position.z);
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }
    //private void FlipSprite()
    //{
    //    bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
    //    if(playerHasHorizontalSpeed)
    //    {
    //        this.transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
    //    }
    //}
}
