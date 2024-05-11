using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    Vector3 offset;
    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerTransform.position + offset;
    }
}
