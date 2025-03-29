using UnityEngine;
using TMPro;

public class ScoreSum : MonoBehaviour
{

    public Live live;
    public TimeCal timecal;
    float scoreLive = 0;
    float scoreTime = 0;
    float scoreWin = 400;
    float scoreFinal;

    public TMP_Text scoreText;  // UI Text show score

    void Start()
    {
        scoreSummary();
    }
    void AllScore()
    {
        //live------------------------
        if (live.currentLives >= 3)
        {
            scoreLive =+300;
        }
        if (live.currentLives == 2)
        {
            scoreLive = +200;
        }
        if (live.currentLives == 1)
        {
            scoreLive = +100;
        }

        //Time-------------------------
        if (timecal.timeElapsed <= 60)
        {
            scoreLive = +300;
        }
        if (live.currentLives >= 61)
        {
            scoreLive = +200;
        }
        if (live.currentLives >= 120)
        {
            scoreLive = +100;
        }
    }

    void scoreSummary()
    {
        scoreText.text = "Score" + scoreFinal;
        scoreFinal = scoreLive + scoreTime + scoreWin;   
    }
}
