using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Options
{
    public static string easy = "easy" ;
    public static string medium = "medium" ;
    public static string hard = "hard" ;
    
    public static string easyScore = "easyScore" ;
    public static string mediumScore = "mediumScore" ;
    public static string hardScore  = "hardScore" ;
    
    public static string easyCoin = "easyCoin" ;
    public static string mediumCoin = "mediumCoin" ;
    public static string hardCoin = "hardCoin" ;

    public static string musicOn = "musicOn" ;

    public static void MakeItEasy(int easy)
    {
        PlayerPrefs.SetInt(Options.easy,easy);
    }

    public static int ReadEasy()
    {
        return PlayerPrefs.GetInt(Options.easy);
    }
    public static void MakeItMedium(int medium)
    {
        PlayerPrefs.SetInt(Options.medium,medium);
    } 
    public static int ReadMedium()
    {
        return PlayerPrefs.GetInt(Options.medium);
    }
    public static void MakeItHard(int hard)
    {
        PlayerPrefs.SetInt(Options.hard,hard);
    }
    public static int ReadHard()
    {
        return PlayerPrefs.GetInt(Options.hard);
    }
    
    
    
    public static void MakeItEasyScore(int easyScore)
    {
        PlayerPrefs.SetInt(Options.easyScore,easyScore);
    }

    public static int ReadEasyScore()
    {
        return PlayerPrefs.GetInt(Options.easyScore);
    }
    public static void MakeItMediumScore(int mediumScore)
    {
        PlayerPrefs.SetInt(Options.mediumScore,mediumScore);
    } 
    public static int ReadMediumScore()
    {
        return PlayerPrefs.GetInt(Options.mediumScore);
    }
    public static void MakeItHardScore(int hardScore)
    {
        PlayerPrefs.SetInt(Options.hardScore,hardScore);
    }
    public static int ReadHardScore()
    {
        return PlayerPrefs.GetInt(Options.hardScore);
    }
    
    
    
    
    
    public static void MakeItEasyCoin(int easyCoin)
    {
        PlayerPrefs.SetInt(Options.easyCoin,easyCoin);
    }

    public static int ReadEasyCoin()
    {
        return PlayerPrefs.GetInt(Options.easyCoin);
    }
    public static void MakeItMediumCoin(int mediumCoin)
    {
        PlayerPrefs.SetInt(Options.mediumCoin,mediumCoin);
    } 
    public static int ReadMediumCoin()
    {
        return PlayerPrefs.GetInt(Options.mediumCoin);
    }
    public static void MakeItHardCoin(int hardCoin)
    {
        PlayerPrefs.SetInt(Options.hardCoin,hardCoin);
    }
    public static int ReadHardCoin()
    {
        return PlayerPrefs.GetInt(Options.hardCoin);
    }

    
    public static void MakeItMusicOn(int musicOn)
    {
        PlayerPrefs.SetInt(Options.musicOn,musicOn);
    }
    public static int ReadMusicOn()
    {
        return PlayerPrefs.GetInt(Options.musicOn);
    }
    
    public static bool Record()
    {
        if (PlayerPrefs.HasKey(Options.easy) || PlayerPrefs.HasKey(Options.medium) || PlayerPrefs.HasKey(Options.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool MusicOnRecord()
    {
        if (PlayerPrefs.HasKey(Options.musicOn))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
