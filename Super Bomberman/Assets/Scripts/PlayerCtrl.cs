using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {
    public float speedPlayer = 1f;
    Rigidbody2D rig;
    float h = 0, v = 0;
    Animator anim;
    public GameObject bomb;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rig.velocity = new Vector2(h * speedPlayer, v * speedPlayer);
        MovePlayer();
        if (ButtonManager.countbomb > 0)
        {
            Bomb();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyX" || col.gameObject.tag == "EnemyY")
        {
            ButtonManager.isDied = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "BombItem")
        {
            ButtonManager.countbomb += 1;
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "OverWall")
        {
            ButtonManager.overWall = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "ActiveBomb")
        {
            ButtonManager.activeBomb = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "PowerBomb")
        {
            ButtonManager.powerbomb += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Explosion")
        {
            ButtonManager.isDied = true;
            Destroy(gameObject);
        }

    }

    void Bomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {     
            Vector3 posbomb = transform.position;
            posbomb.x = Mathf.Round(transform.position.x*10)/10;
            posbomb.y = Mathf.Round(transform.position.y*10)/10;
            Instantiate(bomb, posbomb, transform.rotation);
            ButtonManager.countbomb -= 1;
        }
    }

    void MovePlayer()
    {
        anim.SetFloat("Horizontal", h);
        anim.SetFloat("Vertical", v);

        if(rig.velocity != Vector2.zero)
        {
            anim.SetInteger("move", 1);
        }
        else
        {
            anim.SetInteger("move", 0);
        }

        if (v == 1)
        {
            anim.SetInteger("idleup", 1);
            anim.SetInteger("idledown", 0);
            anim.SetInteger("idleleft", 0);
            anim.SetInteger("idleright", 0);
        }
        if (v == -1)
        {
            anim.SetInteger("idleup", 0);
            anim.SetInteger("idledown", 1);
            anim.SetInteger("idleleft", 0);
            anim.SetInteger("idleright", 0);
        }

        if (h == 1)
        {
            anim.SetInteger("idleup", 0);
            anim.SetInteger("idledown", 0);
            anim.SetInteger("idleleft", 0);
            anim.SetInteger("idleright", 1);
        }

        if (h == -1)
        {
            anim.SetInteger("idleup", 0);
            anim.SetInteger("idledown", 0);
            anim.SetInteger("idleleft", 1);
            anim.SetInteger("idleright", 0);
        }
    }
}
