using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class Aircraft : MonoBehaviour
{
    protected float bulletSpeed;
    protected float reloadTime;
    protected bool canShoot = true;
    protected string bulletName;

    // Assigning values
    public abstract void SetValues();

    // Reading values from the file
    public void ReadValuesFromFile(string name, ref float bulletSpeed, ref float reloadTime, ref string bulletName)
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
            lineIndex++;
        }
        reader.Close();
    }

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
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100 * bulletSpeed * Time.deltaTime);
            canShoot = false;
            StartCoroutine(Reload());
        }
    }
}
