using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Điều khiển Player
public class PlayerCtrl : MonoBehaviour
{
    Rigidbody rig;
    public float playerSpeed = 5f;// Tốc độ di chuyển của Player
    float h, v;
    Vector3 target;
    public static float bloodPlayer = 5f;// Lượng máu của player
    public GameObject panelBlood, lostBlood;// Gán thanh máu và trạng thái mất máu của Player từ Editor
    // Use this for initialization
    void Start()
    {
        bloodPlayer = 5f;
        rig = GetComponent<Rigidbody>();
        SetBlood();// Hiển thị thanh máu
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();//Thao tác di chuyển Player
        RotateGun();// Điều khiển hướng xoay súng (shoot)
    }

    //Player chỉ di chuyển trái phải, trên dưới
    private void MovePlayer()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        rig.velocity = new Vector3(h * playerSpeed, v * playerSpeed, 0);
    }

    //Player xoay theo hướng vị trí chuột
    void RotateGun()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10000000));// Chuyển vị trí chuột từ tọa đồ màn hình sang tọa độ thực
        transform.LookAt(target);//Player luôn hướng về vị trí chuột
    }

    private void OnTriggerEnter(Collider col)
    {
        //Sự kiện xảy ra khi Box va chạm với Player
        if(col.gameObject.tag == "Box")
        {
            bloodPlayer -= 1;// bị mất một ô máu
            SetBlood(); // reset hiển thị lại trạng thái thanh máu
            Instantiate(lostBlood, transform.position, Quaternion.identity);// Tạo trạng thái mất máu
            Destroy(col.gameObject);// Phá hủy Box
        }
    }

    //Hiển thị trạng thái thanh máu
    void SetBlood()
    {
        // Mặc định có 5 ô máu, số lượng ô máu hiển thị sẽ tương ứng với số máu hiện tại
        for (int i = 0; i < 5; i++)
        {
            if (i < bloodPlayer)
            {
                panelBlood.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                panelBlood.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }
}
