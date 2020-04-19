using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Ctrl : MonoBehaviour
{
    public float speedEnemy = 0.5f;
    Rigidbody2D rig;
    Animator anim;
    //float posX, posY;
    public GameObject enemyExplosion;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "EnemyX")
        {
            rig.velocity = transform.right * speedEnemy;
        }

        if (gameObject.tag == "EnemyY")
        {
            if (rig.velocity.y > 0)
            {
                anim.SetBool("move", true);
            }
            else
            {
                anim.SetBool("move", false);
            }
            rig.velocity = transform.up * speedEnemy;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "StoneWall" || col.gameObject.tag == "WoodWall" || col.gameObject.tag == "ItemWall" || col.gameObject.tag == "Bomb")
        {
            if (gameObject.tag == "EnemyX")
            {
                transform.right = -transform.right;
            }

            if (gameObject.tag == "EnemyY")
            {
                transform.up = -transform.up;
            }
        } 

        if(col.gameObject.tag == "EnemyX" || col.gameObject.tag == "EnemyY")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            ButtonManager.score += 1;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            ButtonManager.countEnemy -= 1;
            Destroy(gameObject);
        }
    }
}
