using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI healthText = null;
    public PlayerStats playerStats;
    public GameObject waveIndicator;
    public GameObject pauseMenu;
    public GameObject deathMenu;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.Damaged += (sender, args) => healthText.text = "Lives: " + playerStats.currentHealth;
        playerStats.Scored += (sender, args) => scoreText.text = playerStats.playerPoints.ToString();
    }
}
