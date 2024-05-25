using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefapTest : MonoBehaviour
{
    public GameObject prefap;
    public Transform SpawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        // <- 이걸 풀면 /*prepab 생성*/Instantiate(prefap);/*기본 위치 , 회전 값 적용*/
        /*prepab 생성*/Instantiate(prefap, SpawnTransform.position, Quaternion.identity);/*특정 위치 , 자신의 회전 값 적용*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnPrefab();
        }
    }
    private void SpawnPrefab()
    {
        Instantiate(prefap, SpawnTransform.position, Quaternion.identity);
    }
}
