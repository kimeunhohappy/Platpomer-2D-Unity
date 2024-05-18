using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMTEST : MonoBehaviour
{
    public GameObject TestObject;
    private void Awake()
    {
        Debug.Log("Awake ����");
        TestObject = new GameObject();
    }
    private void Start()
    {
        Debug.Log("Start ����");
        TestObject.SetActive(false);
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable ����");
    }
    public void FixedUpdate()
    {
        Debug.Log("FixedUpdate ����");
    }
    public void Update()
    {
        Debug.Log("Update ����");
    }
    public void LateUpdate()
    {
        Debug.Log("LateUpdate ����");
    }
}
