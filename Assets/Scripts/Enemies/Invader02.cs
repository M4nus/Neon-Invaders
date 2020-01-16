using System.Collections;
using UnityEngine;

public class Invader02 : Aircraft
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
        ReadValuesFromFile("Invader02", ref bulletSpeed, ref reloadTime, ref bulletName);
    }
}
