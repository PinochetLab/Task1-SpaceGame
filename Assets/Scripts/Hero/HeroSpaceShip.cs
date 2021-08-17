using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpaceShip : MonoBehaviour, IHitGetable
{
	public bool immortal = false;
	public float blinkFreq = 2f;

	float time = 0;
	SpriteRenderer sprite;

	private void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}
	public void GetHit() {
		LivesController.DeleteLive();
	}

	private void Update() {
		if ( immortal ) {
			time += Time.deltaTime;
			if (time > 1 / blinkFreq ) {
				time = 0;
				sprite.enabled = !sprite.enabled;
			}
		}
		else {
			sprite.enabled = true;
		}
	}
}
