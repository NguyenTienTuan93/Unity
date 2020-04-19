using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCtrl : MonoBehaviour {
    public GameObject panel;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
            else if(Time.timeScale == 0)
            {
                panel.SetActive(false);
                Time.timeScale = 1;
            }            
        }
	}

    public void LoadScene()
    {
        
    }

    public void Replay()
    {
        panel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
}
