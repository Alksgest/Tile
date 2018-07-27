using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D enemyRigidbody;
    private BoxCollider2D enemyBoxCollider;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
        
    }
    private void Run()
    {
        if (IsfacingRight())
        {
            enemyRigidbody.velocity = new Vector2(moveSpeed, enemyRigidbody.velocity.y); //enemyRigidbody.velocity.y
        }
        else
            enemyRigidbody.velocity = new Vector2(-moveSpeed, enemyRigidbody.velocity.y);
    }

    private bool IsfacingRight()
    {
        return this.transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
    }

}
