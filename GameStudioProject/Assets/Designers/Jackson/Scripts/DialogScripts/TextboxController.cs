using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yarn.Unity
{
    public class TextboxController : MonoBehaviour
    {
        public PlayerInput input;
        public AudioManager audioManager;

        void Update()
        {
            if (input.interact)
            {
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning)
                {
                    FindObjectOfType<DialogueUI>().MarkLineComplete();
                }
            }
        }

        [YarnCommand("startVoiceLine")]
        public void StartVoiceLine(string name)
        {
            Debug.Log("yarn command working");
            audioManager.Play(name);
        }

        [YarnCommand("stopVoiceLine")]
        public void StopVoiceLine()
        {
            audioManager.Stop();
        }

        [YarnCommand("loadNextScene")]
        public void LoadNextScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        [YarnCommand("disableMovement")]
        public void DisableMovement()
        {
            //this doesnt work yet hehe
        }

        [YarnCommand("enableMovement")]
        public void EnableMovement()
        {
            //this doesnt work yet either >:(
        }

    }
}
