using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text enegryText;
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRecharge;
    int energy;
    const string energyKey = "Energy";
    const string energyReadyKey = "EnergyReady";
    private void Start()
    {
        scoreText.text = "High Score:\n" + PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0).ToString();

        energy = PlayerPrefs.GetInt(energyKey, maxEnergy);
        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(energyReadyKey, string.Empty);
            if (energyReadyString == string.Empty) { return; }
            DateTime energyReady = DateTime.Parse(energyReadyString);
            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(energyKey, energy);
            }
        }
        enegryText.text = "Play (" + energy + ")";
    }
    public void Play()
    {
        if (energy <= 0) { return; };
        energy--;
        PlayerPrefs.SetInt(energyKey, energy);
        if (energy <= 0)
        {
            PlayerPrefs.SetString(energyReadyKey, DateTime.Now.AddMinutes(energyRecharge).ToString());
        }
        SceneManager.LoadScene("Game");
    }
}
