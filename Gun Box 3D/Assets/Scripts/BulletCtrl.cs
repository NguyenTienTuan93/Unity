using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Điều khiển Viên đạn
public class BulletCtrl : MonoBehaviour {
    public float bulletSpeed = 100f;// Tốc độ bay viên đạn
    Rigidbody rig;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        Destroy(gameObject, 2);// viên đạn bị phá hủy sau 2 giây được tạo ra
	}
	
	// Update is called once per frame
	void Update () {
        rig.velocity = transform.forward * bulletSpeed;// Bắn viên đạn theo hướng chỉ của súng (shoot)
	}
}
