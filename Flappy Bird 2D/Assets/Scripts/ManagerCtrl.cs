using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCtrl : MonoBehaviour {
    public GameObject wall, panelStart, panelStop;
    public static int countWall = 5;
    public static bool isDied;
    // Use this for initialization
    void Start () {
        //DontDestroyOnLoad(gameObject);
        Time.timeScale = 0;
        for (int i = 0; i< 5; i++)
        {
            CreatWall(-4.5f + 4.5f*i);
        }
        panelStart.SetActive(true);
        panelStop.SetActive(false);
        isDied = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (countWall < 5)
        {
            CreatWall(12.5f);
            countWall++;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                panelStop.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                panelStop.SetActive(false);
            }
        }

        if (isDied)
        {
            Time.timeScale = 0;
            panelStop.SetActive(true);
        }
    }

    void CreatWall(float x)
    {
        Instantiate(wall, new Vector3(x, 0, transform.position.z), transform.rotation);
    }

    public void Play()
    {
        panelStart.SetActive(false);
        Time.timeScale = 1;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        if (!isDied)
        {
            Time.timeScale = 1;
            panelStop.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
