using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float bulletSpeed = 0.1f;

    public void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    public void Move()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * input * playerSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPooler.sharedInstance.GetPooledObject("PlayerBullet01");
        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000 * bulletSpeed * Time.deltaTime);
        }
    }
}
