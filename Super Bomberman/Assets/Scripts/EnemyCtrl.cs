using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {
    public float speedEnemy = 0.5f;
    float move= 0;
    Rigidbody2D rig;
    public float maxX = 2f, maxY = 2f;
    Animator anim;
    //float posX, posY;
    public GameObject enemyExplosion;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        move = speedEnemy;
    }

    // Update is called once per frame
    void Update() {
        if(gameObject.tag == "EnemyX")
        {
            if (move > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            rig.velocity = new Vector2(move, 0);
        }

        if (gameObject.tag == "EnemyY")
        {

            if (move > 0)
            {
                anim.SetBool("move", true);
            }
            else
            {
                anim.SetBool("move", false);
            }
            rig.velocity = new Vector2(0, move);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "StoneWall" || col.gameObject.tag == "WoodWall"|| col.gameObject.tag == "ItemWall" || col.gameObject.tag == "Bomb")
        {
            if(gameObject.tag == "EnemyX")
            {
                if (col.gameObject.transform.position.x < gameObject.transform.position.x)
                {
                    move = speedEnemy;
                }
                else if (col.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    move = -speedEnemy;
                }
            }

            if (gameObject.tag == "EnemyY")
            {
                if (col.gameObject.transform.position.y < gameObject.transform.position.y)
                {
                    move = speedEnemy;
                }
                else if (col.gameObject.transform.position.y > gameObject.transform.position.y)
                {
                    move = -speedEnemy;
                }
            }
        }

        if(col.gameObject.tag == "Explosion")
        {
            ButtonManager.score += 1;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
