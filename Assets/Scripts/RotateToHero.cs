using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToHero : MonoBehaviour
{
	Transform player;

	private void Start() {
		player = GameObject.FindWithTag("Player")?.transform;
	}

	private void Update() {
		if ( !player ) return;
		transform.up = (player.position - transform.position).normalized;
	}
}
