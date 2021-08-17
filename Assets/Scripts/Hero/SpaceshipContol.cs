using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipContol : MonoBehaviour
{
	[SerializeField] float rotateSpeed;
	[SerializeField] float force;
	[SerializeField] float maxSpeed;

	[SerializeField] Shooter shooter;

	public bool arrows = false;

	float realRotateSpeed;
	Rigidbody2D rb;

	private void Start() {
		realRotateSpeed = rotateSpeed / 40;
		rb = GetComponent<Rigidbody2D>();
	}
	void MouseLookControl() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float a = -ray.origin.z / ray.direction.z;
		Vector3 mousePoint = ray.origin + a * ray.direction;
		Vector3 dir = (mousePoint - transform.position).normalized;
		Quaternion target = Quaternion.FromToRotation(Vector3.up, dir);
		transform.rotation = Quaternion.Lerp(transform.rotation, target, realRotateSpeed * Time.deltaTime);
	}

	void ArrowsControl() {
		float ver = Input.GetAxis("VerticalArrow");
		float hor = Input.GetAxis("HorizontalArrow");
		if ( ver == 0 && hor == 0 ) return;
		Vector3 dir = (Vector3.up * ver + Vector3.right * hor).normalized;
		Quaternion target = Quaternion.FromToRotation(Vector3.up, dir);
		transform.rotation = Quaternion.Lerp(transform.rotation, target, realRotateSpeed * Time.deltaTime);
	}

	private void Update() {
		if ( !arrows ) MouseLookControl();
		else ArrowsControl();
		shooter.automatic = arrows;
	}

	private void FixedUpdate() {
		float ver = Input.GetAxis("Vertical");
		float hor = Input.GetAxis("Horizontal");
		if ( ver == 0 && hor == 0 ) return;
		Vector3 dir = (Vector3.up * ver + Vector3.right * hor).normalized;
		rb.AddForce(dir * force);
		if ( rb.velocity.magnitude > maxSpeed ) rb.velocity = rb.velocity.normalized * maxSpeed;
	}
}
