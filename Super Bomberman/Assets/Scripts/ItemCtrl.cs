using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour {
    // Use this for initialization
    int random, count;
    void Start () {
        count = gameObject.transform.childCount;
        random = Random.Range(0, count);
        for (int i = 0; i< count; i++)
        {
            if (i != random)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
