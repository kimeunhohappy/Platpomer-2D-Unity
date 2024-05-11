using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("�̸�")]
    public float movespeed = 5f;
    private float moveInput;
    public float JumpForce = 10f;
    public Transform startTransform;
    public Rigidbody2D rigidbody2D;

    [Header("����")]
    public bool IsGrounded;
    public float groundDistance = 2f;
    public LayerMask grundLayer;

    [Header("�ø�")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;
    [Header("Animation")]
    public Animator anim;
    private bool isMove;

    // Start is called before the first frame update
    //ù ������ ���� �� 1�� ����
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
    // 1�����Ӵ� 1�� ����
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
    /// �÷��̾� �̵��� �ʿ��� Bool ���� �����ϴ� �Լ�
    /// </summary>
    private void CollisionCheck()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, grundLayer);
    }
    /// <summary>
    /// ������ �Է��� �����ϴ� �Լ�
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
    /// ���� : Y Position _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ�ȴ�.
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
