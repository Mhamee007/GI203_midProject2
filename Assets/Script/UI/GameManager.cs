using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
}