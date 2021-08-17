using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLO : MonoBehaviour, IRewarded, IHitGetable
{

	[SerializeField] float speed = 3;
	[SerializeField] int reward = 200;

	Rigidbody2D rb;
	private void Start() {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = speed * Mathf.Sign(Random.Range(-1f, 1f)) * Vector3.right;
	}

	public void Reward() {
		ScoreManager.AddScore(reward);
	}

	public void GetHit() {
		Reward();
		gameObject.SetActive(false);
	}
}
