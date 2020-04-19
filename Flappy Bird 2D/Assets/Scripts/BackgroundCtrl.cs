using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCtrl : MonoBehaviour {
    public float speedBackground = 0.02f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            transform.position -= Vector3.right * speedBackground;
        }
        if (transform.position.x <= -17.5f)
        {
            transform.position = new Vector2(20f, transform.position.y);
        }
	}
}
