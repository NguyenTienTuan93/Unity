using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Điều khiển Box
public class BoxCtrl : MonoBehaviour {
    public GameObject explosion;// Gán đối tượng vụ nổ từ Editor
    GameObject target;//đối tượng mà box di chuyển tới
    public float speed = 0.1f; // Tốc độ di chuyển của box
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");// gán đối tượng Box di chuyển tới là gameobject có tag là Player
        speed += 0.05f * GameManager.level;// Tốc độ di chuyển của Box theo từng level
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);// Di chuyển box về phía Player
	}

    private void OnTriggerEnter(Collider other)
    {
        //Các sự kiện xảy ra khi viên đạn va chạm với Box
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);// hình thành vụ nổ
            GameManager.point += 1*(GameManager.level + 1);// Điểm tăng lên tùy level đang chơi
            GameManager.countlevel += 1;//Số lần bắn trúng tăng lên một, đủ 5 lần sẽ tăng 1 level
            Destroy(other.gameObject);// Phá hủy viên đạn
            Destroy(gameObject);// Phá hủy Box
        }
    }
}
