using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TimeCal timeCal;
    private int scoreTime = 0;
    private int scoreWin = 600;
    private int scoreFinal = 0;

    public static GameManager Instance;

    public int finalScore;  // Score that persists between scenes

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this GameObject alive across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates

        }
    }

    public void SaveScore(int score)
    {
        finalScore = score;
        Debug.Log("Score Saved: " + finalScore);

    }

 
    void Start()
    {

    }

    void Update()
    {
        CalculateScoreTime();
    }

    public void CalculateScoreTime()
    {
        timeCal = FindObjectOfType<TimeCal>();
        if (timeCal != null)
        {
            float timeElapsed = timeCal.timeElapsed;
            Debug.Log("Time Elapsed: " + timeElapsed); // Debugging log

            if (timeElapsed <= 80)
                scoreTime = 400;
            else if (timeElapsed > 80 && timeElapsed <= 160)
                scoreTime = 200;
            else
                scoreTime = 100;
        }

        scoreFinal = scoreTime + scoreWin;
        Debug.Log("Final Score: " + scoreFinal);
        GameManager.Instance.SaveScore(scoreFinal);
    }
   

    public void ResetScore()
    {
        scoreFinal = 0;
        scoreTime = 0;
        scoreWin = 400;
    }

}