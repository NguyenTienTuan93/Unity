using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour {
    public float speedWall = 0.02f;
    // Use this for initialization
    void Start () {
        float range;
        Vector3 posTopWall, posBotWall;
        posTopWall = this.transform.GetChild(0).gameObject.transform.position;
        posBotWall = this.transform.GetChild(1).gameObject.transform.position;
        range = Random.Range(13f, 15f);
        posTopWall.y = Random.Range(3f, 10f);
        posBotWall.y = Mathf.Clamp(posTopWall.y - range,-10,-3);

        transform.GetChild(0).gameObject.transform.position = posTopWall;
        transform.GetChild(1).gameObject.transform.position = posBotWall;
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 1)
        {
            transform.position -= Vector3.right * speedWall;
        }
        if(transform.position.x <= -10f)
        {  
            ManagerCtrl.countWall--;
            Destroy(gameObject);
        }
    }
}
