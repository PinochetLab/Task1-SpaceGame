using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	Text text;

	private void Start() {
		text = GetComponent<Text>();
	}

	private void Update() {
		text.text = ScoreManager.score.ToString();
	}
}
