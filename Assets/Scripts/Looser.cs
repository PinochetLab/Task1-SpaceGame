using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looser : MonoBehaviour
{
    public static void Loose() {
		GameObject.FindObjectOfType<PauseController>()?.NewGame();
	}
}
