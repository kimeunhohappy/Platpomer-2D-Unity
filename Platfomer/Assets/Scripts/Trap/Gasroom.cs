using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasroom : Trap
{
    private bool isGasState = false;
    private int playerHp = 100;
    private int Damge = 0;
    public bool isStayOn = true;
    public float checktime;
    public float Timer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            // Player�� �˾ƾ� �� �ʿ伺�� �ְ���. PlayerController <- �ٸ� Ŭ�������� ���� Ŭ������ ��� ������ ���ΰ�?
            isGasState = true;
            Debug.Log($"�÷��̾ ���� ���� ���� ���� : {isGasState}");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = false;
            Debug.Log($"�÷��̾ ���� ���� ���� ���� : {isGasState}");
        }
    }

    private void Update() // PlayerController�� Update���� �ۼ��ϴ� �� ������.
    {
        if (isGasState)   // { } ���� �濡 ���� ���� ���� �ۼ��Ѵ�. ü���� ���̴� ������ ���÷� �ۼ��Ͽ���.
        {
            // ���� �ð��� ���� Time.deltaTime
            //checkTime = 2f;
            Timer += Time.deltaTime; // 0.016. ��ǻ�͸��� �ٸ���. 1Frame �����ϴ� �ð�.
            if (Timer >= checktime)
            {
                Timer = 0;
                playerHp = playerHp - Damge;
                Debug.Log($"�÷��̾��� ���� ü�� : {playerHp}");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            Debug.Log($"�÷��̾ ���� �����̹Ƿ� �÷��̾��� ü���� ���� ��Ű�� �ִ�.");
            playerHp = playerHp - Damge;
            Debug.Log($"�÷��̾��� ���� ü�� : {playerHp}");
        }
    }

}
