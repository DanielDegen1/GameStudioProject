using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity
{
    public class DialogOnCollision : MonoBehaviour
    {
        public string talkToNode = "";

        public YarnProgram scriptToLoad;

        // Start is called before the first frame update
        void Start()
        {
            DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning)
                {
                    FindObjectOfType<DialogueRunner>().Stop();
                }
                FindObjectOfType<DialogueRunner>().StartDialogue(talkToNode);
                Destroy(gameObject);
            }
        }
    }
}
