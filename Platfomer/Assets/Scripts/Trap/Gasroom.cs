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
            // Player가 알아야 할 필요성이 있겠죠. PlayerController <- 다른 클래스에서 나의 클래스를 어떻게 접근할 것인가?
            isGasState = true;
            Debug.Log($"플레이어가 현재 가스 진입 상태 : {isGasState}");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = false;
            Debug.Log($"플레이어가 현재 가스 진입 상태 : {isGasState}");
        }
    }

    private void Update() // PlayerController의 Update에서 작성하는 게 맞지만.
    {
        if (isGasState)   // { } 가스 방에 들어갔을 때의 로직 작성한다. 체력을 깍이는 로직을 예시로 작성하였다.
        {
            // 단위 시간을 제어 Time.deltaTime
            //checkTime = 2f;
            Timer += Time.deltaTime; // 0.016. 컴퓨터마다 다르다. 1Frame 생성하는 시간.
            if (Timer >= checktime)
            {
                Timer = 0;
                playerHp = playerHp - Damge;
                Debug.Log($"플레이어의 현재 체력 : {playerHp}");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            Debug.Log($"플레이어가 가스 상태이므로 플레이어의 체력을 감소 시키고 있다.");
            playerHp = playerHp - Damge;
            Debug.Log($"플레이어의 현재 체력 : {playerHp}");
        }
    }

}
