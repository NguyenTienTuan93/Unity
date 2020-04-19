using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Script quản lý chung của game
public class GameManager : MonoBehaviour
{
    public float creatTime = 2f;// Thời gian tạo box
    float countTime; // Biến đếm khoảng thời gian tạo box
    public GameObject box, panelStart, panelStop; // Gán các đối tượng Box, Panel Start, Panel Stop từ Editor
    public Text txtPoint, txtHighScore, txtStatus ; // gán các Text hiển thị điểm, điểm cao nhất, trạng thái từ Editor
    bool isDie; // trạng thái game over hay không
    public static int level, countlevel, point, highscore;
    // Use this for initialization
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        init();
    }

    //Khởi tạo các thông số khi bắt đầu và replay game
    private void init()
    {
        countTime = 0;// reset biến đếm khoảng thời gian để tạo box mới về 0
        isDie = false;// reset lại trạng thái game không gameover
        level = 0; // reset lại tốc độ di chuyển box về mức ban đầu
        countlevel = 0; // reset lại biến đếm số box để tăng level
        point = 0; // gán lại điểm ban đầu bằng 0
        Time.timeScale = 0;// Dừng trò chơi trước khi play
        panelStart.SetActive(true); // Hiển thị giao diện UI bắt đầu game
        panelStop.SetActive(false); // Tắt hiển thị giao diện UI kết thúc game

        //Kiểm tra đã có điểm số cao nhất chưa
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        txtPoint.text = "Point: " + point.ToString();// Hiển thị điểm số người chơi theo thời gian thực

        //Gán lại điểm số cao nhất highscore theo thời gian thực
        if (point > highscore)
        {
            highscore = point;
        }
        txtHighScore.text = "High Score: " + highscore.ToString();

        //Tăng level sau mỗi 5 box (tốc độ nhanh hơn)
        if (countlevel >= 5)
        {
            level += 1;
            countlevel = 0;
        }

        //Tạo Box xuất hiện vị trí ngẫu nhiên sau một khoảng thời gian
        float randomPosX = Random.Range(-10f, 10f);
        countTime += Time.deltaTime;
        if (countTime > creatTime)
        {
            Instantiate(box, transform.position + new Vector3(randomPosX, 1, 10), Quaternion.identity);
            countTime = 0;
        }

        //Pause game khi nhấn phím P
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        //Game over khi máu người chơi về 0
        if (PlayerCtrl.bloodPlayer <= 0)
        {
            Die();
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        panelStart.SetActive(false);
    }

    //Nếu game đang play thì thì sẽ Pause game và ngược lại
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            txtStatus.text = "Pause";
            Time.timeScale = 0;
            panelStop.SetActive(true);
        }
        else if (!isDie)// Nếu đang pause game mà game ở trạng thái game over thì sẽ không có tác dụng
        {
            Time.timeScale = 1;
            panelStop.SetActive(false);
        }
    }

    //Quay trở lại game đang chơi
    public void Resume()
    {
        //Chỉ quay lại game khi không ở trạng thái game over
        if (!isDie) {
            Time.timeScale = 1;
            panelStop.SetActive(false);
        }
    }

    //Reset lại game
    public void Replay()
    {
        PlayerPrefs.SetInt("highscore", highscore);// Lưu lại điểm cao nhất
        init();// Khởi tạo lại các thông số màn chơi
        SceneManager.LoadScene(0);// load lại màn chơi
    }

    //Thoát game
    public void Quit()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        Application.Quit();
    }

    //Trạng thái game over
    void Die()
    {
        Time.timeScale = 0;
        txtStatus.text = "GAME OVER";
        panelStop.SetActive(true);
    }
}
