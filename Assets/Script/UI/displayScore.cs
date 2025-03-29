using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int finalScore = GameManager.Instance.finalScore;
        scoreText.text = "Score: " + finalScore;
    }
}