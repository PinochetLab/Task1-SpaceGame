using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
	[SerializeField] GameObject pauseWindow;
	[SerializeField] Button resumeButton;
	[SerializeField] Text controlText;

	SpaceshipContol spaceshipContol;

	private void Start() {
		Time.timeScale = 0;
		spaceshipContol = GameObject.FindObjectOfType<SpaceshipContol>();
	}

	private void Update() {
		if ( Input.GetButtonDown("Pause") ) {
			if ( pauseWindow.activeSelf ) HideMenu();
			else ShowMenu();
		}
	}

	bool arrows = true;

    public void ShowMenu() {
		pauseWindow.SetActive(true);
		Time.timeScale = 0;
	}

	public void HideMenu() {
		resumeButton.interactable = true;
		pauseWindow.SetActive(false);
		Time.timeScale = 1;
	}

	public void NewGame() {
		HideMenu();
		ScoreManager.score = 0;
		LivesController.Regame();
		PoolSpawner.instance.DeactivateAll();
	}

	public void ChangeControl() {
		arrows = !arrows;
		spaceshipContol.arrows = arrows;
		if ( arrows ) controlText.text = "КЛАВИАТУРА";
		else controlText.text = "КЛАВИАТУРА + МЫШЬ";
	}

	public void Exit() {
		Application.Quit();
	}
}
