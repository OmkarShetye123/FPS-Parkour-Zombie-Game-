using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingBlock : MonoBehaviour
{
    public bool up;

    public float height;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (up)
        {
            transform.Translate(Vector3.up * height * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int luck = Random.Range(0, 2);
            up = (luck == 1) ? true:false;
        }
    }
}
