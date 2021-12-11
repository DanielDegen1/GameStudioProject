using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuscript : MonoBehaviour
{
    public GameObject musicController;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ButtonMainMenu(){
        SceneManager.LoadScene("MenuScene");

    }
    public void ButtonStart() {
        Destroy(musicController);
        SceneManager.LoadScene("BasicMovementTutorial");
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
