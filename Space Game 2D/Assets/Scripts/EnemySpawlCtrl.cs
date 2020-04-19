using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawlCtrl : MonoBehaviour {
    public GameObject enemy, camera;
    //Camera camera;
    float PosX, PosY = 0;
    public float time = 2f;
    float lifetime = 0;
    Vector3 Pos;
	// Use this for initialization
	void Start () {
        Pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        lifetime = lifetime + Time.deltaTime;
        if (lifetime >= time)
        {
            int ran = Random.Range(1, 100);
            if(ran%2 == 0)
            {
                PosX = transform.position.x + Random.Range(4f, 5f) * (Random.Range(0, 2) * 2 - 1);
                PosY = transform.position.y + Random.Range(0f, 6f) * (Random.Range(0, 2) * 2 - 1);
            }
            else
            {
                PosX = transform.position.x + Random.Range(0f, 5f) * (Random.Range(0, 2) * 2 - 1);
                PosY = transform.position.y + Random.Range(5f, 6f) * (Random.Range(0, 2) * 2 - 1);
            }         
            Pos = new Vector3(PosX, PosY,transform.position.z);
            Debug.Log(Pos);
            Instantiate(enemy, Pos, transform.rotation);
            lifetime = 0;
        }

    }
}
