using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public float borderPosition;
    public float invadersSpeed;
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * invadersSpeed * Time.fixedDeltaTime);
        if(transform.position.x >= borderPosition || transform.position.x <= -borderPosition)
        {
            invadersSpeed *= -1;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
    }
}
