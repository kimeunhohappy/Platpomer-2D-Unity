using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] MovePostions;
    public float speed;
    public int moveindex;
    bool OnGoingForawd = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Isworking = true;
    }
    private void Movetrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePostions[moveindex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, MovePostions[moveindex].position) < 0.15f)
        {
            if (moveindex == 0)
            {
                //Flip(OnGoingForawd);
                OnGoingForawd = true;
            }

            if (OnGoingForawd)
                moveindex++;
            else
                moveindex--;

            if (moveindex >= MovePostions.Length)
            {
                moveindex = MovePostions.Length - 1;
                OnGoingForawd = false;
            }
        }
    }
    private void Update()
    {
        anim.SetBool("isWorking", Isworking);
        Movetrap();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
