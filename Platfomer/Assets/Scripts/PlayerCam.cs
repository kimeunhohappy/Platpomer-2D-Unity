using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    Vector3 offset;
    public Transform PlayerTransform;
    public float fixedyposition;
    [Range(0f, 1f)]
    public float smoothVaule;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerTransform.position;
        fixedyposition = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPoition = PlayerTransform.position + offset;
        targetPoition.y = fixedyposition;
        Vector3 smoothPoition = Vector3.Lerp(transform.position, targetPoition, smoothVaule);
        transform.position = PlayerTransform.position + offset;
    }
}
