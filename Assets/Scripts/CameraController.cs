using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        pos = target.position + offset;

        transform.position = pos;
    }

}
