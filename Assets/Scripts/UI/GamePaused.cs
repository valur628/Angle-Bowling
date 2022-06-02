using UnityEngine;
using System.Collections;

public class GamePaused : MonoBehaviour
{

    public GameObject DarkestPanel;
    public GameObject GameStopText;
    public GameObject GameResume;
    public GameObject GameRestart;
    public GameObject MainMenu;

    public bool paused;
    void Start()
    {
        paused = false;
        DarkestPanel.SetActive(false);
        GameStopText.SetActive(false);
        GameResume.SetActive(false);
        MainMenu.SetActive(false);
        GameRestart.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            paused = !paused;
            if (paused && Time.timeScale == 1.0F)
            {
                GameMainManager.GamePulse = true;
                DarkestPanel.SetActive(true);
                GameStopText.SetActive(true);
                GameResume.SetActive(true);
                GameRestart.SetActive(true);
                MainMenu.SetActive(true);
            }
            else if (!paused && Time.timeScale == 0.0F)
            {
                GameMainManager.GamePulse = false;
                DarkestPanel.SetActive(false);
                GameStopText.SetActive(false);
                GameResume.SetActive(false);
                GameRestart.SetActive(false);
                MainMenu.SetActive(false);
            }
        }
    }
    public void GameResumeControl()
    {
        GameMainManager.GamePulse = false;
        DarkestPanel.SetActive(false);
        GameStopText.SetActive(false);
        GameResume.SetActive(false);
        GameRestart.SetActive(false);
        MainMenu.SetActive(false);
    }
}