using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text easyScore, easyCoin, mediumScore, mediumCoin, hardScore, hardCoin;
    // Start is called before the first frame update
    void Start()
    {
        easyScore.text = "Score: " + Options.ReadEasyScore();
        easyCoin.text = " X " + Options.ReadEasyCoin();
        
        easyScore.text = "Score: " + Options.ReadMediumScore();
        easyCoin.text = " X " + Options.ReadMediumCoin();
        
        easyScore.text = "Score: " + Options.ReadHardScore();
        easyCoin.text = " X " + Options.ReadHardCoin();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
