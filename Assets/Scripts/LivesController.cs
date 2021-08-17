using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
	public static int lives = 0;
	public static LivesController instance;
	[SerializeField] int startLives = 5;

	private void Start() {
		instance = this;
		lives = startLives;
	}

	public void ReGame() {
		lives = startLives;
	}

	public static void Regame() {
		instance.ReGame();
	}

	public static void DeleteLive() {
		lives--;
		if ( lives == 0 ) Looser.Loose();
	}
}
