using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    public void ButtonMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void ButtonStart() {
        SceneManager.LoadScene(1);
    }
    public void ButtonOptions() {
        SceneManager.LoadScene(2);
    }
    public void ButtonCredits() {
        SceneManager.LoadScene(3);
    }
    public void ButtonQuit() {
        Application.Quit();
    }
}
