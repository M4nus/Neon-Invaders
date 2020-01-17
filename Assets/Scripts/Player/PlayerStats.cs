using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int playerPoints;

    public event EventHandler<DamagedEventArgs> Damaged;
    public event EventHandler<ScoredEventArgs> Scored;
    public event EventHandler Died;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        playerPoints = 0;
    }

    public void ScorePoints(int points)
    {
        playerPoints += points;
        Scored(this, new ScoredEventArgs(points));
    }

    public void DealDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Damaged(this, new DamagedEventArgs(damage));

        if(currentHealth == 0)
            Died(this, new EventArgs());
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
