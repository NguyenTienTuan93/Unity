using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCtrl : MonoBehaviour {
    public float lifetime = 0.2f;
    public float countdown = 0;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        countdown += Time.deltaTime;
        if (countdown >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
