using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("�̸�")]
    public float Movespeed = 5f;
    private float moveInput;
    public float JumpForse = 10f;
    public Transform startTransform;
    public Rigidbody2D rigidbody2D;

    [Header("����")]
    public bool IsGrounded;
    public float grounDistance = 2f;
    public LayerMask grundLayer;
    // Start is called before the first frame update
    //ù ������ ���� �� 1�� ����
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("SBSGAMEACADMY and CSHARP(C#,C ++ ++, C++++) is so very good!");
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1�����Ӵ� 1�� ����
    void Update()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, grounDistance, grundLayer);
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(Movespeed * moveInput, rigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true) //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) IsGrounded�� true,false�ۿ� ���� �׳� �ᵵ �ȴ�.(�ݴ�:!IsGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - grounDistance));
    }
}
