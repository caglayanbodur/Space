using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;
    // Start is called before the first frame update
    void Start()
    {
        if (Options.ReadEasy() == 1)
        {
            easyButton.interactable = false;
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }
        if (Options.ReadMedium() == 1)
        {
            easyButton.interactable = true ;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }
        if (Options.ReadHard() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
        
    }

    public void ButtonSelect(string level)
    {
        switch (level)
        {
            case "easy":
                Options.MakeItEasy(1);
                Options.MakeItMedium(0);
                Options.MakeItHard(0);
                easyButton.interactable = false;
                mediumButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "medium":
                Options.MakeItEasy(0);
                Options.MakeItMedium(1);
                Options.MakeItHard(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                Options.MakeItEasy(0);
                Options.MakeItMedium(0);
                Options.MakeItHard(1);
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
                break;
            default:
                break;
            
        }
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
