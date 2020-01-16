using System.Collections;
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
        bulletSpeed = 60f;
        reloadTime = 12f;
        canShoot = true;
        bulletName = "EnemyBullet01";
        chanceToFailAShot = 50;
    }
}
