using System.Collections;
using UnityEngine;

public class Invader03 : Aircraft
{
    void OnEnable()
    {
        SetValues();
        StartCoroutine(DelayBeforeShot());
    }

    void Update()
    {
        if(canShoot)
            Shoot();
    }

    public override void SetValues()
    {
        ReadValuesFromFile("Invader03");
    }
}
