using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuscript : MonoBehaviour
{
    private Music musicRef;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        musicRef = (Music)FindObjectOfType(typeof(Music));

    }
    public void ButtonMainMenu(){
        SceneManager.LoadScene("MenuScene");

    }
    public void ButtonStart() {
        Destroy(musicRef.gameObject);
        SceneManager.LoadScene("BasicMovementTutorial");
    }
    public void ButtonOptions() {
        SceneManager.LoadScene("OptionsScene");
    }
    public void ButtonControls()
    {
        SceneManager.LoadScene("ControlScene");
    }
    public void ButtonCredits() {
        SceneManager.LoadScene("CreditsScene");
    }
    public void ButtonQuit() {
        Application.Quit();
    }
}
