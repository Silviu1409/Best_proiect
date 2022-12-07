using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI ammoInGunText;
    public TextMeshProUGUI ammoLeftText;
    private int score = 0;
    private int highscore = 0;
    //private int ammo = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        //scoreText.text = score.ToString() + " POINTS";
        scoreText.text = score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        //ammoText.text= "AMMO: \u221E";
        ammoInGunText.text = "0";
        ammoLeftText.text = "\u221E";
    }

    void Update()
    {
        //metoda adaugat puncte de test
        if (Input.GetKeyDown(KeyCode.M))
            AddPoint();
        //resetare high score de test
        if (Input.GetKeyDown(KeyCode.N))
            PlayerPrefs.SetInt("highscore", 0);
    }


    public void AddPoint()
    {
         
        score += 1;
        scoreText.text = score.ToString();
        //scoreText.text = score.ToString() + " POINTS";
        if (score>highscore)
            PlayerPrefs.SetInt("highscore",score);
    }
}
