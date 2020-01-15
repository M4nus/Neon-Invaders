using System.Collections;
using UnityEngine;

public class Invader03 : Enemy
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
        bulletSpeed = 30f;
        reloadTime = 7f;
        canShoot = true;
    }

    public override void Shoot()
    {
        GameObject bullet = ObjectPooler.sharedInstance.GetPooledObject("EnemyBullet02");
        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.Rotate(0, 0, 180);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100 * bulletSpeed * Time.deltaTime);
        }
        canShoot = false;
        StartCoroutine(Reload());
    }
}
