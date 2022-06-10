using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    private int score;
    private int highestScore;
    private int coin;
    private int highestCoin;
    private bool collectScore = true;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text gameOverScoreText;
    [SerializeField] private Text gameOverCoinText;

    void Start()
    {
        coinText.text = "X " + coin;
    }

    void Update()
    {
        if (collectScore == true)
        {
            score = (int) Camera.main.transform.position.y;
            scoreText.text ="Score : " + score;  
        }
        
        
    }

    public void WinCoin()
    {
        coin++;
        coinText.text = "X " + coin;

    }

    public void GameEnd()
    {
        if (Options.ReadEasy() == 1)
        {
            highestScore = Options.ReadEasyScore();
            highestCoin = Options.ReadEasyCoin();
            if (score > highestScore)
            {
                Options.MakeItEasyScore(score);
            }
            if (coin > highestCoin)
            {
                Options.MakeItEasyCoin(coin);
            }
        }
        
        if (Options.ReadMedium() == 1)
        {
            highestScore = Options.ReadMediumScore();
            highestCoin = Options.ReadMediumCoin();
            if (score > highestScore)
            {
                Options.MakeItMediumScore(score);
            }
            if (coin > highestCoin)
            {
                Options.MakeItMediumCoin(coin);
            }
        }
        
        if (Options.ReadHard() == 1)
        {
            highestScore = Options.ReadHardScore();
            highestCoin = Options.ReadHardCoin();
            if (score > highestScore)
            {
                Options.MakeItHardScore(score);
            }
            if (coin > highestCoin)
            {
                Options.MakeItHardCoin(coin);
            }
        }
        collectScore = false;
        gameOverScoreText.text = "Score: " + score;
        gameOverCoinText.text = " X " + coin;
    }
}
