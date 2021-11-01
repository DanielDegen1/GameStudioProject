using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity
{
    public class DialogOnPress : MonoBehaviour
    {
        public PlayerInput input;

        public string talkToNode = "";

        public YarnProgram scriptToLoad;


        // Start is called before the first frame update
        void Start()
        {
            DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);
        }

        // Update is called once per frame
        void Update()
        {
            if (input.interact)
            {
                if (!FindObjectOfType<DialogueRunner>().IsDialogueRunning)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(talkToNode);
                }
            }
        }
    }
}
