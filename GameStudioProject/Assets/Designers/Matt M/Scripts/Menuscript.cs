using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuscript : MonoBehaviour
{
    public GameObject musicController;
    public void ButtonMainMenu(){
        SceneManager.LoadScene("MenuScene");

    }
    public void ButtonStart() {
        SceneManager.LoadScene("BasicMovementTutorial");
        Destroy(GameObject.FindGameObjectWithTag("Music Player"));
    }
    public void ButtonOptions() {
        SceneManager.LoadScene("OptionsScene");
    }
    public void ButtonCredits() {
        SceneManager.LoadScene("CreditsScene");
    }
    public void ButtonQuit() {
        Application.Quit();
    }
}
