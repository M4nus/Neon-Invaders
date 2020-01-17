using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Unbreakable"))
        {
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerStats>().DealDamage(damage);
            }
            else if(collision.gameObject.layer == LayerMask.NameToLayer("Invaders"))
            {
                // I will implement that later
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().ScorePoints(10);
                collision.gameObject.SetActive(false);
            }
            else
                collision.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
