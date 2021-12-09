using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameHandler gameHandler;
    public void Crash()
    {
        gameObject.SetActive(false);
        gameHandler.EndGame();
    }
}
