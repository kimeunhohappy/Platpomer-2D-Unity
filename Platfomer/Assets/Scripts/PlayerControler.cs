using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("이름")]
    public float movespeed = 5f;
    private float moveInput;
    public float JumpForce = 10f;
    public Transform startTransform;
    public Rigidbody2D rigidbody2D;

    [Header("점프")]
    public bool IsGrounded;
    public float groundDistance = 2f;
    public LayerMask grundLayer;

    [Header("플립")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;
    [Header("Animation")]
    public Animator anim;
    private bool isMove;

    // Start is called before the first frame update
    //첫 프레임 시작 전 1번 실행
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("SBSGAMEACADMY and CSHARP(C#,C++ ++, C++++) is so very good!");
        transform.position = startTransform.position;
    }
    void InitializePlayerStatus()
    {
        rigidbody2D.velocity = Vector3.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1프레임당 1번 실행
    void Update()
    {
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Move();

        FallDownCheck();
    }


    /// <summary>
    /// 플레이어 이동에 필요한 Bool 값을 제어하는 함수
    /// </summary>
    private void CollisionCheck()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, grundLayer);
    }
    /// <summary>
    /// 유저의 입력을 관리하는 함수
    /// </summary>
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            Jump();
        }
    }


    private void Move()
    {
        rigidbody2D.velocity = new Vector2(movespeed * moveInput, rigidbody2D.velocity.y);
    }

    /// <summary>
    /// 점프 : Y Position _ rigidbody Y velocity를 점프 파워만큼 올려주면된다.
    /// </summary>
    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }

    private void HandleAnimation()
    {
        isMove = rigidbody2D.velocity.x != 0;
        anim.SetBool("isMove", isMove);
        anim.SetBool("isGrounded", IsGrounded);
        anim.SetFloat("yVelocity", rigidbody2D.velocity.y);
    }

    private void HandleFlip()
    {
        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        else if (!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void FallDownCheck()
    {
        if (transform.position.y < -11)
        {
            InitializePlayerStatus();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
