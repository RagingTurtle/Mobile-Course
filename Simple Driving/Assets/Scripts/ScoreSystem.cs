using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    float score;
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }
}
