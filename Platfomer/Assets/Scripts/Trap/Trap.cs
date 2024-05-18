using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected bool Isworking = false;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (/* �÷��̾ �浹�ߴ°�? */collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player�� �������� �ǰݴ��ߴ�!(collision)");
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (/* �÷��̾ �浹�ߴ°�? */collision.CompareTag("Player"))
        {
            Debug.Log("Player�� �������� �ǰݴ��ߴ�!(trigger)");
        }
    }
}
