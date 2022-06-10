using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Sprite[] musicIkons;

    [SerializeField] private Button musicButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Options.Record() == false)
        {
            Options.MakeItEasy(1);
            
        }

        if (Options.MusicOnRecord() == false)
        {
            Options.MakeItMusicOn(1);
        }
        CheckMusicSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("Score");
    } 
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Music()
    {
        if (Options.ReadMusicOn() == 1)
        {
            Options.MakeItMusicOn(0);
            musicButton.image.sprite = musicIkons[0];
            
        }
        else
        {
            Options.MakeItMusicOn(1);
            musicButton.image.sprite = musicIkons[1];
        }
    }

    public void CheckMusicSettings()
    {
        if (Options.ReadMusicOn() == 1)
        {
            musicButton.image.sprite = musicIkons[1];
        }
        else
        {
            musicButton.image.sprite = musicIkons[0];

        }
    }
}
