using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour {
    //Declare
    Rigidbody rig;
    public static bool isflying = false;// The ball move with the Pad
    AudioSource music;
    Vector3 firstBallPos;
    Transform parent;
    public float speedBall = 5f;
    public Vector3 test;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        music = GetComponent<AudioSource>();
        firstBallPos = transform.localPosition;// the first position of the ball relative to the Pad
        parent = transform.parent;// the first Tranform of the Pad
    }
	
	// Update is called once per frame
	void Update () {
        test = rig.velocity;
        //Click the space key to Play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isflying)//isflying is used to click the space only once
            {
                return;
            }
            else
            {
                transform.parent = null;// Seperating the ball from the Pad after Playing
                rig.velocity = new Vector3(speedBall, 0, speedBall);
                //rig.AddForce(new Vector3(0, 0, ballSpeed));
                isflying = true;
            }
        }

        //Change speed ball
        if (PadCtrl.isItem)
        {
            rig.velocity = new Vector3(rig.velocity.x * ManagerCtrl.changeSpeedBall, rig.velocity.y, rig.velocity.z * ManagerCtrl.changeSpeedBall);
            ManagerCtrl.changeSpeedBall = 1;
            PadCtrl.isItem = false;
        }

        //Conditon to lose blood
        if (transform.position.z < -11)
        {
            ManagerCtrl.blood -= 1;
            ResetBall();//The ball returns the first position of it realtive to the Pad
        }

        //Reset ball when the game is winning (No more Bricks)
        if (ManagerCtrl.countBrick <= 0)
        {
            ResetBall();//The ball returns the first position of it realtive to the Pad
        }
    }

    //Make a sound when the ball collides with other objects
    private void OnCollisionEnter(Collision col)
    {
        music.Play();
    }

    //The ball returns the first position of it realtive to the Pad
    void ResetBall()
    {
        isflying = false;
        rig.velocity = Vector3.zero;
        transform.parent = parent;
        transform.localPosition = firstBallPos;   
    }
}
