using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected bool Isworking = false;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (/* 플레이어가 충돌했는가? */collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player가 함정에게 피격당했다!(collision)");
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (/* 플레이어가 충돌했는가? */collision.CompareTag("Player"))
        {
            Debug.Log("Player가 함정에게 피격당했다!(trigger)");
        }
    }
}
