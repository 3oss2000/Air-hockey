using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuload : MonoBehaviour {
    
    public void PlayGame()
    {
        SceneManager.LoadScene("main");
    }
}