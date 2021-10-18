using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuscript : MonoBehaviour
{
    public GameObject musicController;
    public void ButtonMainMenu(){
        SceneManager.LoadScene("MenuScene");
        DontDestroyOnLoad(musicController.gameObject);

    }
    public void ButtonStart() {
        SceneManager.LoadScene("GameScene");
        Destroy(musicController.gameObject);
    }
    public void ButtonOptions() {
        SceneManager.LoadScene("OptionsScene");
        DontDestroyOnLoad(musicController.gameObject);
    }
    public void ButtonCredits() {
        SceneManager.LoadScene("CreditsScene");
        DontDestroyOnLoad(musicController.gameObject);
    }
    public void ButtonQuit() {
        Application.Quit();
    }
}
