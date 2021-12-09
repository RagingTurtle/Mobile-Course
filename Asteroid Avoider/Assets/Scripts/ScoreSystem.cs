using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    public bool isCrashed = false;
    float score;
    void Update()
    {
        if (!isCrashed)
        {
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
    }

    public float GetScore()
    {
        return score;
    }
    public void Crash()
    {
        isCrashed = true;
        scoreText.text = string.Empty;
    }
}
