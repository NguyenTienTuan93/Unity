using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCtrl : MonoBehaviour {
    public float lifetime = 2f;
    public float countdown = 0;
    public GameObject explosion;
    RaycastHit2D hitright, hitleft, hitup, hitdown;
    // Use this for initialization
    void Start () {
        GetComponent<CircleCollider2D>().isTrigger = true; 
	}
	
	// Update is called once per frame
	void Update () {
        countdown += Time.deltaTime;
        if (ButtonManager.activeBomb)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Explosion();
            }
        }
        if (countdown >= lifetime)
        {
            Explosion();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
        if (col.gameObject.tag == "Explosion")
        {
            Explosion();
        }
    }

    void Explosion()
    {
        int layerMask = LayerMask.GetMask("Bomb");
        layerMask = ~layerMask;
        hitright = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), 2, layerMask);
        hitleft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.left), 2, layerMask);
        hitup = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 2, layerMask);
        hitdown = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), 2, layerMask);
        Instantiate(explosion, transform.position, transform.rotation);
        for (int i = 1; i <= Mathf.Min(hitright.distance * 10 +1 , ButtonManager.powerbomb); i++)
        {
            Instantiate(explosion, transform.position + new Vector3(0.1f, 0, 0) * i, transform.rotation);
        }
        for (int i = 1; i <= Mathf.Min(hitleft.distance * 10 + 1, ButtonManager.powerbomb); i++)
        {
            Instantiate(explosion, transform.position + new Vector3(-0.1f, 0, 0) * i, transform.rotation);
        }
        for (int i = 1; i <= Mathf.Min(hitup.distance * 10 + 1, ButtonManager.powerbomb); i++)
        {
            Instantiate(explosion, transform.position + new Vector3(0, 0.1f, 0) * i, transform.rotation);
        }
        for (int i = 1; i <= Mathf.Min(hitdown.distance * 10 + 1, ButtonManager.powerbomb); i++)
        {
            Instantiate(explosion, transform.position + new Vector3(0, -0.1f, 0) * i, transform.rotation);
        }
        ButtonManager.countbomb += 1;
        Destroy(gameObject);
    }
}
