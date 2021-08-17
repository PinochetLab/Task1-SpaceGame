using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{
	Text text;

	private void Start() {
		text = GetComponent<Text>();
	}

	private void Update() {
		text.text = LivesController.lives.ToString();
	}
}
