using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public Vector3 startVec;
    public Vector3 edgeVec;

    public float amplitude;

    public float speed = 5f;

    private void Start()
    {
        startVec = transform.position;
    }

    private void Update()
    {
        transform.position = startVec + transform.right * amplitude * (Mathf.Sin(Time.time * speed)) ;
    }
}
