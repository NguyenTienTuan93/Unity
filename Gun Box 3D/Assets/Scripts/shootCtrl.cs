using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Điều khiển Súng (Shoot)
public class shootCtrl : MonoBehaviour {
    public GameObject bullet;// Gán đối tượng viên đạn từ Editor
    AudioSource aud;// Âm thanh khi bắn đạn
    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //Viên đạn sẽ bắn ra khi nhấn chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            aud.Play();
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
