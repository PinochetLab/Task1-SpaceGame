using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClickTrigger : MonoBehaviour
{
	[SerializeField] UnityEvent action;

	private void Update() {
		if ( Input.GetMouseButtonDown(0) ) {
			action.Invoke();
		}
	}
}
