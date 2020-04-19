using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour {
    public GameObject item;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && (gameObject.tag == "WoodWall"|| gameObject.tag == "ItemWall"))
        {
            if (ButtonManager.overWall)
            {
                GetComponent<CircleCollider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            if (gameObject.tag == "WoodWall")
            {
                Destroy(gameObject);
            }

            if (gameObject.tag == "ItemWall")
            {
                Instantiate(item, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
