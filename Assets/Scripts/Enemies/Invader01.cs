using System.Collections;
using UnityEngine;

public class Invader01 : Enemy
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
        bulletSpeed = 60f;
        reloadTime = 2f;
        canShoot = true;
    }
}
