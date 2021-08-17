using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsPortalSystem : MonoBehaviour
{
	float xLimit;
	float yLimit;
	float padding = 0.5f;

	private void Start() {
		Vector2 position = (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
		xLimit = position.x + padding;
		yLimit = position.y + padding;
	}

	private void Update() {
		float x = transform.position.x;
		float y = transform.position.y;

		if (Mathf.Abs(x) > xLimit ) {
			x = -xLimit * Mathf.Sign(x);
		}

		if ( Mathf.Abs(y) > yLimit ) {
			y = -yLimit * Mathf.Sign(y);
		}

		transform.position = new Vector2(x, y);
	}
}
