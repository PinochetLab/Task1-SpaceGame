using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHitable
{
	float maxDistance;
	[SerializeField] float speed = 10f;
	float s = 0;

	private void OnEnable() {
		s = 0;
	}

	private void Start() {
		float screenAspect = (float)Screen.width / (float)Screen.height;
		float camHalfHeight = Camera.main.orthographicSize;
		float camHalfWidth = screenAspect * camHalfHeight;
		float camWidth = 2.0f * camHalfWidth;
		maxDistance = camWidth;
	}

	private void Update() {
		transform.position += transform.up * speed * Time.deltaTime;
		s += speed * Time.deltaTime;
		if ( s > maxDistance ) {
			gameObject.SetActive(false);
		}
	}

	public void Hit(IHitGetable target) {
		target.GetHit();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if ( other.tag == gameObject.tag ) return;
		IHitGetable _target = other.GetComponent<IHitGetable>();
		if ( _target != null) {
			Hit(_target);
			gameObject.SetActive(false);
		}
	}
}
