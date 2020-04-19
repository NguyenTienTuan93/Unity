using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        int ranItem;
        ranItem = Random.Range(0, 2);
        //Choose Item is actived
        if (ranItem == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * ManagerCtrl.speedItem);// Item automatically moves down
        //Condition to destroy Item
        if (transform.position.z < -12)
        {
            Destroy(gameObject);
        }
    }
}
