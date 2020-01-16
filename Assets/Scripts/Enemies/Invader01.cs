﻿using System.Collections;
using UnityEngine;

public class Invader01 : Aircraft
{
    void Start()
    {
        SetValues();
    }

    void Update()
    {
        if(canShoot)
            Shoot();
    }

    public override void SetValues()
    {
        ReadValuesFromFile("Invader01", ref bulletSpeed, ref reloadTime, ref bulletName);
    }
}
