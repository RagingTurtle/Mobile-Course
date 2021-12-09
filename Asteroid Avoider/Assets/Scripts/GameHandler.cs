using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] TMP_Text GameOverText;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AsteroidSpawner asteroidSpawner;
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        scoreSystem.Crash();
        int finalScore = Mathf.FloorToInt(scoreSystem.GetScore());
        GameOverText.text = "Score: " + finalScore + "\nGAME OVER";
        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
