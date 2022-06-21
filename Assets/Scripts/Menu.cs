using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;

    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void Quit() {
        Application.Quit();
    }

}
