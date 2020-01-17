using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIFunctionalities : MonoBehaviour
{
    [SerializeField] private GameController gameController = null;
    [SerializeField] private GameObject UIDisplay;
    private StatsDisplay statsDisplay;

    public int wave;

    public void Awake()
    {
        UIDisplay = GameObject.Find("UIDisplay");
        statsDisplay = UIDisplay.GetComponent<StatsDisplay>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    #region Functionalities

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        gameController.isPreparing = true;
        statsDisplay.playerStats.ResetStats();
        statsDisplay.playerStats.DealDamage(0);
        ObjectPooler.sharedInstance.CleanAllObjects();
    }

    public void Resume()
    {
        gameController.isInvasion = true;
    }   

    public void Wave(bool toggle)
    {
        statsDisplay.waveIndicator.SetActive(toggle);
        statsDisplay.waveIndicator.GetComponent<TextMeshProUGUI>().text = "Wave: " + wave;
    }

    public void Pause(bool toggle)
    {
        statsDisplay.pauseMenu.SetActive(toggle);
    }

    public void Dead(bool toggle)
    {
        statsDisplay.deathMenu.SetActive(toggle);
    }

    #endregion
}
