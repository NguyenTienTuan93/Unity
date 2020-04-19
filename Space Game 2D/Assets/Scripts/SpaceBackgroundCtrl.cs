using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBackgroundCtrl : MonoBehaviour {
    public GameObject camera, player;
    SpriteRenderer spr;
    Rigidbody2D rig;
	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        rig = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        spr.material.mainTextureOffset += rig.velocity / 2000f;
	}
}
