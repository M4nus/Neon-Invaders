using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public float borderPosition;
    public float invadersSpeed;
    public float baseSpeed;
    public bool canEnemiesMove = false;

    private void Start()
    {
        baseSpeed = invadersSpeed;
    }

    void Update()
    {
        if(canEnemiesMove)
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
        // Condition to fail. I don't like that it's there either :P
        if(transform.position.y < -5f)
            GameObject.Find("GameController").GetComponent<GameController>().isDead = true;
    }

    public void ResetSpeed()
    {
        invadersSpeed = baseSpeed;
    }
}
