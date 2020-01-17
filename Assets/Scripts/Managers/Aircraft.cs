using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class Aircraft : MonoBehaviour
{
    protected float bulletSpeed;
    protected float reloadTime;
    protected bool canShoot = false;
    protected string bulletName;
    protected int damage;
    protected int points;

    #region Settings


    // Assigning values
    public abstract void SetValues();

    // Reading values from the file
    public void ReadValuesFromFile(string name)
    {
        string path = "Assets/Resources/Data/" + name + ".txt";

        string line;
        int lineIndex = 0;

        StreamReader reader = new StreamReader(path);

        while((line = reader.ReadLine()) != null)
        {
            if(lineIndex == 0)
                bulletSpeed = float.Parse(line);
            else if(lineIndex == 1)
                reloadTime = float.Parse(line);
            else if(lineIndex == 2)
                bulletName = line;
            else if(lineIndex == 3)
                damage = int.Parse(line);
            else if(lineIndex == 4)
                points = int.Parse(line);
            lineIndex++;
        }
        reader.Close();
    }

    // To not make aliens shoot simultaneously
    public IEnumerator DelayBeforeShot()
    {
        yield return new WaitForSeconds(Random.Range(2f, 15f));
        canShoot = true;
    }

    #endregion

    #region Abilities

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
        GameObject bullet = ObjectPooler.sharedInstance.GetPooledObject(bulletName);
        if(bullet != null)
        {
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100 * bulletSpeed * Time.fixedDeltaTime);
            canShoot = false;
            StartCoroutine(Reload());
        }
    }

    #endregion
}
