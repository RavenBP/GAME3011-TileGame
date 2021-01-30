using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject tileGamePrefab;
    [SerializeField]
    GameObject startButton;
    [SerializeField]
    GameObject exitButton;
    [SerializeField]
    Text attemptsText;

    GameObject tileGamePrefabGO;

    // Start Tile Minigame
    public void StartGameButton()
    {
        tileGamePrefabGO = Instantiate(tileGamePrefab, this.transform);
        startButton.SetActive(false);
        exitButton.SetActive(true);
    }

    // Close Tile Minigame
    public void ExitGameButton()
    {
        Destroy(tileGamePrefabGO);
        exitButton.SetActive(false);
        startButton.SetActive(true);
    }
}
