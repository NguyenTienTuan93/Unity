using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCtrl : MonoBehaviour {
    //Start Scene
    public void Play()
    {
        SceneManager.LoadScene(1);//Load GamePlay Scene
    }
}
