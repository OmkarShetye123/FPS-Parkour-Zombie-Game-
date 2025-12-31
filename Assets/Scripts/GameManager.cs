using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;

    public TextMeshProUGUI ammoText; 

    public GameObject blood;

    public Slider healthBar;

    public GameObject ui_ObjectivePanel;
    public GameObject ui_GameOverPanel;
    public GameObject ui_ProfilePanel;
    public GameObject ui_NextButton;

    public TextMeshProUGUI ui_GameOverText;


    public TextMeshProUGUI objectiveText;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(bool win)
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; 
        if (!win)
        {
            ui_GameOverText.text = "Failed!";
            ui_NextButton.SetActive(false);
            ui_ObjectivePanel.SetActive(false);
            ui_ProfilePanel.SetActive(false);
            ui_GameOverPanel.SetActive(true);
            Destroy(player);
        }
        else
        {
            ui_GameOverText.text = "Success!";
            ui_NextButton.SetActive(true);
            ui_ObjectivePanel.SetActive(false);
            ui_ProfilePanel.SetActive(false);
            ui_GameOverPanel.SetActive(true);
            Destroy(player);
        }

    }
}
