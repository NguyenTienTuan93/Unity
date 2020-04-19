using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public GameObject start, panel, enemy, stoneWall, woodWall, itemWall;
    public static bool isDied, overWall, activeBomb;
    public static int score, highscore, countbomb, countEnemy;
    public static float powerbomb;
    public Text txtScore, txtHighscore, txtTitle;
    AudioSource audioSource;
    public float posX = 1.3f, posY = 0.5f;
    int[][] arrayMap;

    // Use this for initialization
    void Start () {
        CreatMap();
        //CreatMap2();
        Time.timeScale = 0;
        start.SetActive(true);
        panel.SetActive(false);
        isDied = false;
        countbomb = 1;
        powerbomb = 1;
        overWall = false;
        activeBomb = false;
        score = 0;
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = 0;
        }
        audioSource = GetComponent<AudioSource>();
        countEnemy = enemy.transform.childCount;
    }
	
	// Update is called once per frame
	void Update () {
        if(isDied)
        {
            txtTitle.text = "GAME OVER";
            panel.transform.GetChild(3).gameObject.SetActive(false);
            PanelOn();
        }

        if(countEnemy <= 0)
        {
            txtTitle.text = "Win";
            panel.transform.GetChild(3).gameObject.SetActive(false);
            PanelOn();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                txtTitle.text = "PAUSE";
                panel.transform.GetChild(3).gameObject.SetActive(true);
                PanelOn();
            }
            else if (Time.timeScale == 0)
            {
                PanelOff();
            }
        }
        if (score > highscore)
        {
            highscore = score;
        }

        txtScore.text = "Score: " + score.ToString();
        txtHighscore.text = "Highscore: " + highscore.ToString();
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void Play()
    {
        audioSource.Play();
        start.SetActive(false);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Replay()
    {
        isDied = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void PanelOn()
    {
        audioSource.Stop();
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    void PanelOff()
    {
        audioSource.Play();
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    void CreatMap()
    {
        float _posX = 0, _posY = 0;
        CreatFrameWall(_posX, _posY);
        CreatStoneWall(_posX, _posY);
        _posX = (float)Random.Range((int)(-posX * 10), (int)(posX * 10)) / 10;
        _posY = (float)Random.Range((int)(-posY * 10), (int)(posY * 10)) / 10;
        int i = 0;
        while (i < 2)
        {
            if (Physics2D.OverlapCircle(new Vector2(_posX, _posY), 0.04f) == null)
            {
                CreatEnemy(_posX, _posY);
                i++;
            }
            else
            {
                _posX = (float)Random.Range((int)(-posX * 10), (int)(posX * 10)) / 10;
                _posY = (float)Random.Range((int)(-posY * 10), (int)(posY * 10)) / 10;
            }

        }
        CreatWoodWall(_posX, _posY);
    }

    void CreatFrameWall(float _posX, float _posY)
    {
        _posX = -posX;
        _posY = posY;
        Instantiate(stoneWall, new Vector3(_posX, _posY, transform.position.z), transform.rotation);
        while (_posX < posX)
        {
            _posX += 0.1f;
            Instantiate(stoneWall, new Vector3(_posX, _posY, transform.position.z), transform.rotation);          
        }
        while (_posY > -(posY-0.1))
        {
            _posY -= 0.1f;
            Instantiate(stoneWall, new Vector3(_posX, _posY, transform.position.z), transform.rotation);
        }
        while (_posX > -posX)
        {
            _posX -= 0.1f;
            Instantiate(stoneWall, new Vector3(_posX, _posY, transform.position.z), transform.rotation);
        }
        while (_posY < (posY - 0.1))
        {
            _posY += 0.1f;
            Instantiate(stoneWall, new Vector3(_posX, _posY, transform.position.z), transform.rotation);
        }
    }

    void CreatStoneWall(float _posX, float _posY)
    {
        _posX = -posX + 0.2f;
        _posY = posY - 0.2f;
        float countbar, countStoneInBar;
        countbar = posX * 10 - 1;
        countStoneInBar = posY * 10 - 1;
        for(int i = 0; i<countbar; i++)
        {
            for (int j = 0; j < countStoneInBar; j++)
            {
                Instantiate(stoneWall, new Vector3(_posX + 0.2f*i, _posY - 0.2f * j, transform.position.z), transform.rotation);
            }
        }
    }

    void CreatWoodWall(float _posX, float _posY)
    {
        _posX = -posX + 0.1f;
        _posY = posY - 0.1f;
        float countbar, countWoodInBar;
        countbar = posX * 2 * 10;
        countWoodInBar = posY * 2 * 10 - 1;
        for (int i = 0; i < countbar; i++)
        {
            for (int j = 0; j < countWoodInBar; j++)
            {
                int ran = Random.Range(0, 3);
                if(ran == 0 || (i == 0 && j == 1)||(i == 1 && j == 0))
                {

                }
                else if (ran == 1 && Physics2D.OverlapCircle(new Vector2(_posX + 0.1f * i, _posY - 0.1f * j), 0.04f) == null)
                {
                        Instantiate(woodWall, new Vector3(_posX + 0.1f * i, _posY - 0.1f * j, transform.position.z), transform.rotation); 
                }
                else if(ran == 2 && Physics2D.OverlapCircle(new Vector2(_posX + 0.1f * i, _posY - 0.1f * j), 0.04f) == null)
                {
                    Instantiate(itemWall, new Vector3(_posX + 0.1f * i, _posY - 0.1f * j, transform.position.z), transform.rotation);
                } 
            }
        }
    }

    void CreatEnemy(float _posX, float _posY)
    {
        int enemyType;
        enemyType = Random.Range(0, 2);
        if(enemyType == 0)
        {
                Instantiate(enemy.transform.GetChild(0).gameObject, new Vector3(_posX, _posY, transform.position.z), transform.rotation);   
        }
        else
        {
                Instantiate(enemy.transform.GetChild(1).gameObject, new Vector3(_posX, _posY, transform.position.z), transform.rotation);
        }
    }
    void CreatMap2()
    {
        CreatArrayMap();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if(arrayMap[i][j] == 0)
                {
                    Instantiate(stoneWall, new Vector3(-posX + 0.1f * i, posY - 0.1f * j, transform.position.z), transform.rotation);
                }
            }
        }
    }

    void CreatArrayMap()
    {
        float countX, countY;
        countX = posX * 2 * 10 + 1;
        countY = posY * 2 * 10 + 1;
        for(int i = 0; i < countX; i++)
        {
            for(int j = 0; j < countY; j++)
            {
                if(i==0 || j==0||i==countX-1||j == countY - 1||(i%2==0 && j%2==0))
                {
                    arrayMap[i][j] = 0;
                }
            }
        }
    }
}
