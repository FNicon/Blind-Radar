using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager> {
	public bool isEndDialogue;
	private Queue<string> sentences;
	private Dialogue input;

	void Start() {
		isEndDialogue = false;
		sentences = new Queue<string>();
		if (DialogueManager.Instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
	}

	//scene load listener credit to: http://answers.unity3d.com/answers/1236899/view.html 
	void OnEnable() {
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneUnloaded += OnSceneLoad;
	}

	void OnDisable() {
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneUnloaded -= OnSceneLoad;
	}

	void OnSceneLoad(Scene scene) {
		DialogueUIManager.Instance.DeactivateDialoguePanel();
	}

	void Update() {
		if (isInputNext()) {
			if (sentences.Count > 0) {
				DisplayNextDialogue();
			} else if ((input != null) && input.nextDialogue != null) {
				StartDialogue(input.nextDialogue);
				DisplayNextDialogue();
			} else {
				DialogueUIManager.Instance.DeactivateDialoguePanel();
			}
		}
	}

	public void StartDialogue(Dialogue inputDialogue) {
		isEndDialogue = false;
		input = inputDialogue;
		DialogueUIManager.Instance.ActivateDialoguePanel(inputDialogue);
		sentences.Clear();
		foreach (string sentence in inputDialogue.dialogues) {
			sentences.Enqueue(sentence);
		}
	}

	public void DisplayNextDialogue() {
		if (sentences.Count == 0) {
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		DialogueUIManager.Instance.StartTypingDialogue(sentence);
	}

	void EndDialogue() {
		sentences.Clear();
		isEndDialogue = true;
	}

	public bool isInputNext() {
		return ((Input.GetButtonUp("Fire1")) || (Input.GetMouseButtonUp(0)));
	}
}

