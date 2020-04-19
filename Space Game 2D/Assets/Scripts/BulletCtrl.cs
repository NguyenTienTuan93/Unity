using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    public float speed = 15f;
    Rigidbody2D rig;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = transform.up * speed;
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {     
        //rig.AddForce(transform.up,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Target")
        {
            SpaceShipCtrl.score += 1;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
