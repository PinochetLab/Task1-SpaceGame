using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartImmortality : MonoBehaviour
{
	[SerializeField] HeroSpaceShip spaceShip;
	[SerializeField] float delay = 3f;

	private void Start() {
		StartCoroutine(Immortality());
	}

	IEnumerator Immortality() {
		spaceShip.immortal = true;
		yield return new WaitForSeconds(delay);
		spaceShip.immortal = false;
	}
}
