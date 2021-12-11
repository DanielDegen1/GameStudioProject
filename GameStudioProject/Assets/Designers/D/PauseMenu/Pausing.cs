using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject pauseMenu;
    private bool isPaused;
    public GameObject camRef;
    private CameraMovement camMovement;
    // Start is called before the first frame update

    void Start() {
        playerInput = GetComponent<PlayerInput>();
        camMovement = camRef.GetComponent<CameraMovement>();
    }

    void Awake()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.Pause)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        camMovement.enabled = false;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        camMovement.enabled = true;
        isPaused = false;

    }
    public void GoToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
