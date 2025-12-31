using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float countdown;

    public float startTime;



    // Start is called before the first frame update
    void Start()
    {
        countdown = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        float min = Mathf.FloorToInt(countdown / 60);
        float sec = Mathf.FloorToInt(countdown % 60);
        GameManager.instance.objectiveText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
