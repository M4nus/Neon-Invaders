using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Unbreakable"))
        {
            collision.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
