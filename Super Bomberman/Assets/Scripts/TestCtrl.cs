using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCtrl : MonoBehaviour {
    // Use this for initialization
    public GameObject explosion;
    RaycastHit2D hitright, hitleft, hitup, hitdown;
    public int count = 2;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        hitright = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), 3);
        hitleft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.left), 3);
        hitup = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 3);
        hitdown = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), 3);
        if (Input.GetKeyDown(KeyCode.B))
        {
            for (int i = 0; i < Mathf.Min(hitright.distance * 10, count); i++)
            {
                Instantiate(explosion, transform.position + new Vector3(0.1f, 0, 0)*i, transform.rotation);
            }
            for (int i = 0; i < Mathf.Min(hitleft.distance * 10, count); i++)
            {
                Instantiate(explosion, transform.position + new Vector3(-0.1f, 0, 0) * i, transform.rotation);
            }
            for (int i = 0; i < Mathf.Min(hitup.distance * 10, count); i++)
            {
                Instantiate(explosion, transform.position + new Vector3(0,0.1f, 0) * i, transform.rotation);
            }
            for (int i = 0; i < Mathf.Min(hitdown.distance * 10, count); i++)
            {
                Instantiate(explosion, transform.position + new Vector3(0,-0.1f, 0) * i, transform.rotation);
            }
        }
    }
}
