using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Aircraft : MonoBehaviour
{
    protected float bulletSpeed;
    protected float reloadTime;
    protected bool canShoot;
    protected string bulletName;
    protected int chanceToFailAShot;

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
        if(Random.Range(0, chanceToFailAShot) % chanceToFailAShot == 0)
        {
            GameObject bullet = ObjectPooler.sharedInstance.GetPooledObject(bulletName);
            if(bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100 * bulletSpeed * Time.deltaTime);
                canShoot = false;
                StartCoroutine(Reload());
            }
        }
    }
}
