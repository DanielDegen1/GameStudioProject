using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipScene : MonoBehaviour
{
    private float timer = 0.0f;
    public float holdDuration = 3.0f;
    PlayerInput playerInput;


    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.Skip)
        {
            Debug.Log("Player is holding");
            timer += Time.deltaTime;
        }
        else
        {
            Debug.Log("Player is not holding");

            timer = 0;
        }

        if(timer >= holdDuration)
        {
            Debug.Log("Cutscene skipped!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
