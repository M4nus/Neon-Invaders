using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Aircraft
{
    public Transform leftBorder;
    public Transform rightBorder;
    public bool canControl;
    public float playerSpeed;

    public void Start()
    {
        SetValues();
        canControl = false;
    }

    public void Update()
    {
        if(canControl)
        {
            Move();
            if(Input.GetKey(KeyCode.Space) && canShoot)
                Shoot();
        }
    }

    public void Move()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * input * playerSpeed * Time.deltaTime);
    }

    public override void SetValues()
    {
        bulletSpeed = -200f;
        reloadTime = 0.5f;
        bulletName = "PlayerBullet01";
        canShoot = true;
    }
}
