using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCtrl : MonoBehaviour {
    //Declare
    public GameObject explosion, item;

    //Collision
    private void OnCollisionEnter(Collision col)
    {
        ManagerCtrl.point += 1;// Increase point when the ball collides with the Bricks (destroy brick)
        ManagerCtrl.countBrick -= 1;// Decrease countBrick when the ball collides with the Bricks (destroy brick)
        CreatItem();//Creat or Not creat Item when the ball collides with the Bricks (destroy brick)
        GameObject Ex = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(Ex, 1);
        Destroy(gameObject);
    }

    //Automatically creat Item
    void CreatItem()
    {
        int ran;
        ran = Random.Range(0, 2);//Creat or Not creat Item
        if(ran == 0)
        {
            Instantiate(item, transform.position, item.transform.rotation);
        }
    }
    // Lưu ý hàm OnDestroy sẽ chạy khi loadscene.
    //private void OnDestroy()
    //{
    //    GameObject Ex = Instantiate(explosion, transform.position, Quaternion.identity);
    //    Destroy(Ex, 1);
    //}
}
