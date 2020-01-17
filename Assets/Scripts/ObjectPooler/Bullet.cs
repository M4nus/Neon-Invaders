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
            // Player is hit
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerStats>().DealDamage(damage);
            }
            // Invaders + bullets are hit
            else if(collision.gameObject.layer == LayerMask.NameToLayer("Invaders"))
            {
                // Not sure how to pass score from enemies there without doing a mess, so leaving that for later
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().ScorePoints(10);
                // Making invaders speed with every kill
                GameObject.Find("Enemies").GetComponent<EnemiesMovement>().invadersSpeed *= 1.1f;
                collision.gameObject.SetActive(false);
                // Checking whether all the invaders were killed.
                if(!ObjectPooler.sharedInstance.CheckActivity("Invader01") && !ObjectPooler.sharedInstance.CheckActivity("Invader02") && !ObjectPooler.sharedInstance.CheckActivity("Invader01"))
                    GameObject.Find("GameController").GetComponent<GameController>().isWon = true;
            }
            // Everything else that's breakable is hit
            else
                collision.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Making sure that bullets won't spawn with more speed
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
