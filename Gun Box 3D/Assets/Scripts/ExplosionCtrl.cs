using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Điều khiển Vụ nổ Box
public class ExplosionCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2); //Vụ nổ sẽ biến mất sau 2 giây được tạo ra
    }
}
