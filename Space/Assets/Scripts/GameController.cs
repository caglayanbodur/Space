using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject bounceButton;
    public GameObject signBoard;
    public GameObject mainMenuButton;
    public GameObject slider;

    void Start()
    {
        gameOverPanel.SetActive(false);
        OpenUI();
    }

  

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        FindObjectOfType<CameraMovement>().GameOver();
        FindObjectOfType<Score>().GameEnd();
        FindObjectOfType<PlayerMovement>().PlayerDie();
        ClosedUI();
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenUI()
    {
        joystick.SetActive(true);
        bounceButton.SetActive(true);
        signBoard.SetActive(true);
        mainMenuButton.SetActive(true);
        slider.SetActive(true);

    }
    public void ClosedUI()
    {
        joystick.SetActive(false);
        bounceButton.SetActive(false);
        signBoard.SetActive(false);
        mainMenuButton.SetActive(false);
        slider.SetActive(false);

    }
}
