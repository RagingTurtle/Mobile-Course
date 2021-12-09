using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] GameObject player;
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
    public void Continue()
    {
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    internal void ContinueGame()
    {
        player.transform.position = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.SetActive(true);
        scoreSystem.resetCrash();
        asteroidSpawner.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }
}
