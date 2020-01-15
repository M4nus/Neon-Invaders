using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float bulletSpeed;
    protected float reloadTime;
    protected bool canShoot;

    //Getting values from file
    public abstract void SetValues();

    public virtual IEnumerator Reload()
    {
        float currentTime = 0f;
        while(currentTime < reloadTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        canShoot = true;
    }

    public virtual void Shoot()
    {
        GameObject bullet = ObjectPooler.sharedInstance.GetPooledObject("EnemyBullet01");
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
