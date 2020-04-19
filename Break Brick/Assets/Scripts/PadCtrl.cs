using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCtrl : MonoBehaviour {
    //Declare
    public float speed = 3;
    float h;
    Rigidbody rig;
    public static bool isItem = false;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Move Pad
        h = Input.GetAxis("Horizontal");
        float x = transform.position.x + Input.GetAxis("Horizontal") * speed;
        transform.position = new Vector3(Mathf.Clamp(x, -5.5f, 5.5f), transform.position.y, transform.position.z);// limit moving range of Pad from -5.5 to 5.5
    }

    //Trigger
    private void OnTriggerEnter(Collider other)
    {
        //Speed down the ball when the Pad receives Time Item
        if(other.gameObject.tag == "timeItem")
        {
            ManagerCtrl.point += 2;
            isItem = true;
            ManagerCtrl.changeSpeedBall = 0.75f;
            Destroy(other.gameObject);
        //Speed up the ball when the Pad receives Speed Item
        }else if(other.gameObject.tag == "speedItem")
        {
            ManagerCtrl.point += 2;
            isItem = true;
            ManagerCtrl.changeSpeedBall = 1.25f;
            Destroy(other.gameObject);
        }
    }
}
