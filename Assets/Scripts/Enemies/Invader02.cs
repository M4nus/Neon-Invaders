using System.Collections;
using UnityEngine;

public class Invader02 : Enemy
{
    void Start()
    {
        SetValues();
    }
    
    void Update()
    {
        if(canShoot)
        {
            Shoot();
        }
    }

    public override void SetValues()
    {
        bulletSpeed = 100f;
        reloadTime = 5f;
        canShoot = true;
    }
}
