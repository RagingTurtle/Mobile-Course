using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text energyText;
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRecharge;
    [SerializeField] AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private Button playButton;
    int energy;
    const string energyKey = "Energy";
    const string energyReadyKey = "EnergyReady";
    private void Start()
    {
        OnApplicationFocus(true);
    }
    private void OnApplicationFocus(bool focusStatus)
    {
        if (!focusStatus) { return; }
        CancelInvoke();
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
            else
            {
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);
            }

        }
    }

    private void Update()
    {
        playButton.interactable = (energy > 0);
        energyText.text = "Play (" + energy + ")";
    }
    private void EnergyRecharged()
    {
        energy = maxEnergy;
        PlayerPrefs.SetInt(energyKey, energy);
    }

    public void Play()
    {
        if (energy < 1) { return; }

        energy--;

        PlayerPrefs.SetInt(energyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRecharge);
            PlayerPrefs.SetString(energyReadyKey, energyReady.ToString());
            androidNotificationHandler.ScheduleNotification(energyReady);
        }

        SceneManager.LoadScene("Game");
    }
}
