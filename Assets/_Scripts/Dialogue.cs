using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/new Dialogue", order = 1)]
public class Dialogue : ScriptableObject {
	//public string actorName;
	[TextArea(3, 10)]
	public string[] dialogues;
	public Sprite actorSprite;
	public Dialogue nextDialogue;
}
