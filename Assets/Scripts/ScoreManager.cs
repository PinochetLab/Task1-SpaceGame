using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public static int score = 0;

	public static void AddScore(int scorePlus) {
		score += scorePlus;
	}
}
