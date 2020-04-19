using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraCtrl : MonoBehaviour {
    public GameObject player;
    public float PosY;
    //Vector3 pos;
	// Use this for initialization
	void Start () {
        PosY = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //pos.x = player.transform.position.x;
        //pos.y = player.transform.position.y + 4f;
        //pos.z = transform.position.z;
        //transform.position = pos;
        if(player.transform.up.y > 0 && player.transform.position.y <= -19f)
        {
            PosY = 1;
        }
        else if(player.transform.up.y < 0 && player.transform.position.y >= 19f)
        {
            PosY = -1;
        }

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -15f, 15f), Mathf.Clamp(player.transform.position.y + 3.5f * PosY, -15f, 15f), transform.position.z);

    }
}
