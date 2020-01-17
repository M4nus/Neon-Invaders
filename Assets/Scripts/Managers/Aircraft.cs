using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

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
        // It works well at assigning variables, but for some reason enemies doesn't shoot if Resources.Load() way of getting external files is enabled.
        // On the other hand, using StreamReader works without any problems, but it can't be build as build files has different paths
        // Have no idea how to fix that.

        /*TextAsset file = (TextAsset)Resources.Load(name);
        
        string fileText = file.text;
        string[] lines = Regex.Split(fileText, "\n");
        for(int i = 0; i < lines.Length; i++)
        {
            bulletSpeed = float.Parse(lines[0]);
            reloadTime = float.Parse(lines[1]);
            bulletName = lines[2];
            damage = int.Parse(lines[3]);
            points = int.Parse(lines[4]);
        }*/

        string path = "Assets/Resources/" + name + ".txt";

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
