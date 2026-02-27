using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    public void AddScore(int additionalScore){
        score += additionalScore;
        scoreText.text = "Score: " + score;
    }

    void Start()
    {
        
    }
}
