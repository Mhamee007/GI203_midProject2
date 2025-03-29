using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSum : MonoBehaviour
{
    private Live live;
    private TimeCal timeCal;

    private int scoreLive = 0;
    private int scoreTime = 0;
    private int scoreWin = 400;
    private int scoreFinal = 0;

    void Start()
    {
        live = FindObjectOfType<Live>();
        timeCal = FindObjectOfType<TimeCal>();

        CalculateScore();
    }

    void CalculateScore()
    {
        if (live != null)
        {
            Debug.Log("Player Lives: " + live.currentLives); // Debugging log

            if (live.currentLives == 3)
                scoreLive = 300;
            else if (live.currentLives == 2)
                scoreLive = 200;
            else if (live.currentLives == 1)
                scoreLive = 100;
            else
                scoreLive = 0; // Just in case
        }

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
