using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSum : MonoBehaviour
{
    public Live live;
    public TimeCal timeCal;

    private int scoreLive = 0;
    private int scoreTime = 0;
    private int scoreWin = 400;
    private int scoreFinal = 0;

    void Start()
    {

        Invoke("CalculateScore", 0.1f);
        CalculateScore();
    }

    public void CalculateScore()
    {
        live = FindObjectOfType<Live>();
        if (live != null)
        {

            float currentLives = live.currentLives;
            Debug.Log("Player Lives: " + live.currentLives); // Debugging log
            live.currentLives--;
            if (currentLives == 3)
                scoreLive = 300;
            else if (currentLives == 2)
                scoreLive = 200;
            else if (currentLives == 1)
                scoreLive = 100;
            else
                scoreLive = 0; // Just in case
        }


        timeCal = FindObjectOfType<TimeCal>();
        if (timeCal != null)
        {
            float timeElapsed = timeCal.timeElapsed;
            Debug.Log("Time Elapsed: " + timeElapsed); // Debugging log

            if (timeElapsed <= 60)
                scoreTime = 300;
            else if (timeElapsed > 60 && timeElapsed <= 120)
                scoreTime = 200;
            else
                scoreTime = 100;
        }

        scoreFinal = scoreLive + scoreTime + scoreWin;
        Debug.Log("Final Score: " + scoreFinal);

        GameManager.Instance.SaveScore(scoreFinal);
    }


}
