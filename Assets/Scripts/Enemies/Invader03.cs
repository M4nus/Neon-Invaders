using System.Collections;
using UnityEngine;

public class Invader03 : Aircraft
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
        bulletSpeed = 30f;
        reloadTime = 30f;
        canShoot = true;
        bulletName = "EnemyBullet02";
        chanceToFailAShot = 60;
    }
}
