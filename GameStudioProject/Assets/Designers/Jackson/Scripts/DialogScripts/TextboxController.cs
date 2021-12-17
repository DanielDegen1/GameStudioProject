using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Yarn.Unity
{
    public class TextboxController : MonoBehaviour
    {
        public PlayerInput input;
        public AudioManager audioManager;
        public Text dialogName;

        public Sprite enikiPortrait, nuzionPortrait, londrosPortrait, cosmosPortrait, champPortrait, possessedPortrait;

        public Image dialogIcon;

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

        [YarnCommand("setNameLabel")]
        public void SetNameLabel(string name)
        {
            dialogName.text = name;
        }

        [YarnCommand("setPortrait")]
        public void SetPortrait(string character)
        {
            switch (character)
            {
                case "nuzion":
                    dialogIcon.sprite = nuzionPortrait;
                    break;
                case "londros":
                    dialogIcon.sprite = londrosPortrait;
                    break;
                case "cosmos":
                    dialogIcon.sprite = cosmosPortrait;
                    break;
                case "eniki":
                    dialogIcon.sprite = enikiPortrait;
                    break;
                case "champion":
                    dialogIcon.sprite = champPortrait;
                    break;
            }
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
