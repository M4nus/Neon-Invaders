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
        bulletSpeed = 100f;
        reloadTime = 20f;
        canShoot = true;
        bulletName = "EnemyBullet01";
        chanceToFailAShot = 40;
    }
}
