using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
	public Dialogue[] dialogues;

	public void SelectDialogue(int dialogueIndex) {
		DialogueManager.Instance.StartDialogue(dialogues[dialogueIndex]);
	}
}
