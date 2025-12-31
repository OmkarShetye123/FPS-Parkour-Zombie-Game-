using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2 : MonoBehaviour
{

    public string[] objectives;
    public bool[] objDone;

    public int password;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.objectiveText.text = objectives[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player.kills >= 10 && !objDone[0])
        {
            GameManager.instance.objectiveText.text = objectives[1];
            objDone[0] = true;
        }
        else if (objDone[1] && !objDone[2])
        {
            GameManager.instance.objectiveText.text = objectives[2];
            objDone[2] = true;
        }       
    }

    public void PasswordEntered(string text)
    {
        if(text == password.ToString())
        {
            objDone[1] = true;
        }
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.GameOver(true);
        }
    }
}
