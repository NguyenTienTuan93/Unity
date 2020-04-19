using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerCtrl : MonoBehaviour {
    //Declare
    public Text txtScore, txtHighScore,txtStatus;// txtStatus displays status Game Play such as Pause or Win or Game over
    public GameObject panelStop, brick, bloodBar;
    public static float point = 0, highscore,blood = 3, countBrick = 0, speedItem = 0.1f;
    public static float changeSpeedBall = 1;
    bool isDie = false, isWin = false;
    // Use this for initialization
    void Start () {
        CreatBrick(); // Automatically creat Brick  
        HighScore();
    }
	
	// Update is called once per frame
	void Update () {
        //Update Point
        Score();

        //Update Blood
        Blood();

        //Lost condition
        if (blood <= 0)
        {
            isDie = true;
        }

        //Win condition (No more Bricks)
        if (countBrick <= 0)
        {
            isWin = true;
        }

        // Reset Brick when winning game
        if (isWin && !BallCtrl.isflying)// isflying = false to reset the Ball before resetting the Bricks (avoid conllision Ball and Bricks)
        {
            isWin = false;
            CreatBrick();
        }
        //Display panelStop and information when losing game
        else if (isDie)
        {
            txtStatus.text = "Game Over";
            Pause();
        }
        //Display panelStop and information when pausing game
        else if (Input.GetKeyDown(KeyCode.P))// click P to pause game
        {
            txtStatus.text = "Pause";
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    //Automatically creat bricks
    void CreatBrick()
    {
        float posX, posZ;
        int ran;
        countBrick = 0;
        //using loop to creat random brick matrix 5x5
        for(int i = 0; i < 5; i++)
        {
            posX = -6 + 3 * i;// position.x of the Bricks
            for(int j = 0; j < 5; j++)
            {
                posZ = 6 - 2 * j;// position.z of the Bricks
                ran = Random.Range(0, 5);// Creat random Brick 
                if (ran != 0)
                {
                    countBrick += 1;
                    Instantiate(brick, new Vector3(posX, 1, posZ), Quaternion.identity);
                }
            }
        }
    }

    //Display Score
    void Score()
    {
        txtScore.text = "Score: " + point.ToString();
        if(point> highscore)
        {
            highscore = point;
        }
        txtHighScore.text = "HighScore: " + highscore.ToString();
        PlayerPrefs.SetFloat("highscore", highscore);// Nên lưu xuống khi kết thúc game sẽ tối ưu hơn
    }

    void HighScore()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetFloat("highscore");
        }
        else
        {
            highscore = 0;
        }

        txtHighScore.text = "HighScore: " + highscore.ToString();
    }

    // Display Blood Bar
    void Blood()
    {
        //using loop to active blood cells
        for(int i = 0; i < 3; i++)
        {
            if (i < blood)
            {
                bloodBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                bloodBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    //Pause Game
    void Pause()
    {
        Time.timeScale = 0;
        panelStop.SetActive(true);
    }

    //Resume Game Play
    public void Resume()
    {
        Time.timeScale = 1;
        panelStop.SetActive(false);
    }

    //Replay Game
    public void Replay()
    {
        //Reset first value
        Time.timeScale = 1;
        changeSpeedBall = 1;
        speedItem = 0.1f;
        blood = 3;
        isDie = false;
        isWin = false;
        point = 0;
        countBrick = 0;
        //Load Game Play
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
