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
        // <- �̰� Ǯ�� /*prepab ����*/Instantiate(prefap);/*�⺻ ��ġ , ȸ�� �� ����*/
        /*prepab ����*/Instantiate(prefap, SpawnTransform.position, Quaternion.identity);/*Ư�� ��ġ , �ڽ��� ȸ�� �� ����*/
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
