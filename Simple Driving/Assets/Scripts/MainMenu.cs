using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private void Start()
    {
        scoreText.text = "High Score:\n" + PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0).ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
