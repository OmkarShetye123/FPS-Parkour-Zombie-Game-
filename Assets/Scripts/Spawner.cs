using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;

    public float repeatRate;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, repeatRate);    
    }

    void Spawn()
    {
        Instantiate(zombie, transform.position, Quaternion.identity);
    }
}
