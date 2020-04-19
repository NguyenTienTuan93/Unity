using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShipCtrl : MonoBehaviour {
    public float speed = 5f, blood = 10f;
    Rigidbody2D rig;
    float h, v;
    public static int score;
    public GameObject bullet, explosion, tale, panel;
    public Text txt_score, txt_highcore, txtscore, txthighscore;
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // Move Spaceship
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rig.velocity = new Vector2(h * speed, v * speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -18f, 18f), Mathf.Clamp(transform.position.y, -20f, 20f), transform.position.z);

        // Rotate SpaceShip
        if (rig.velocity != Vector2.zero)
        {
            transform.up = new Vector3(h, v, 0);
            Instantiate(tale, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        txtscore.text = "Score " + score.ToString();
        if (PlayerPrefs.HasKey("highscore"))
        {
            txthighscore.text = "HighScore " + PlayerPrefs.GetInt("highscore").ToString();
            if(score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            txthighscore.text = "HighScore " + "0";
        }

        txt_score.text = txtscore.text;
        txt_highcore.text = txthighscore.text;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Target")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            blood -= 2f;
            if(blood <= 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }           
        }
    }
}
