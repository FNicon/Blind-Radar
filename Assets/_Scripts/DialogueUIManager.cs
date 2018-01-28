using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIManager : Singleton<DialogueUIManager> {
	//Dialgoues
	public Text actorNameText;
	public Text dialogueText;
	public Image actorImage;
	public GameObject dialoguePanel;
	public GameObject dialogueEndSign;
	public GameObject parentPanel;

	void Awake() {
		if (DialogueUIManager.Instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
	}

	public void ActivateDialoguePanel(Dialogue inputDialogue) {
		parentPanel.SetActive(true);
		actorNameText.text = inputDialogue.actorName;
		actorImage.sprite = inputDialogue.actorSprite;
		//actorImage.SetNativeSize();
		dialoguePanel.SetActive(true);
	}

	public void DeactivateDialoguePanel() {
		dialogueText.text = "";
		dialogueEndSign.SetActive(false);
		actorNameText.text = "";
		actorImage.gameObject.SetActive(false);
		dialoguePanel.SetActive(false);
		parentPanel.SetActive(false);
	}

	public void StartTypingDialogue(string sentence) {
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence) {
		dialogueEndSign.SetActive(false);
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
		dialogueEndSign.SetActive(true);
	}
}
