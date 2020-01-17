using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        playerStats.Damaged += (sender, args) => healthText.text = "Lives: " + playerStats.currentHealth;
        playerStats.Scored += (sender, args) => scoreText.text = playerStats.playerPoints.ToString();
    }
}
