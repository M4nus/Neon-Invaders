using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    private int playerPoints;

    public event EventHandler<DamagedEventArgs> Damaged;
    public event EventHandler<ScoredEventArgs> Scored;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        playerPoints = 0;
    }

    void ScorePoints(int points)
    {
        playerPoints += points;
        if(Scored != null)
            Scored(this, new ScoredEventArgs(points));
    }

    public class DamagedEventArgs : EventArgs
    {
        public DamagedEventArgs(int damage)
        {
            Damage = damage;
        }

        public int Damage { get; private set; }
    }

    public class ScoredEventArgs : EventArgs
    {
        public ScoredEventArgs(int points)
        {
            Points = points;
        }

        public int Points { get; private set; }
    }
}
