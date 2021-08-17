using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AsteroidSize { Big, Medium, Small}
public class Asteroid : MonoBehaviour, IHitGetable, IRewarded, IHitable
{
	[SerializeField] AsteroidSize size;
	[SerializeField] int reward;
	[SerializeField] float minSpeed;
	[SerializeField] float maxSpeed;

	float speed;

	Rigidbody2D rb;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnEnable() {
		speed = Random.Range(minSpeed, maxSpeed);
		float angle = Random.Range(0, 2 * Mathf.PI);
		Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
		rb.velocity = dir * speed;
	}

	public void Redirect(Vector2 dir) {
		rb.velocity = dir.normalized * speed;
	}

	public void Reward() {
		ScoreManager.AddScore(reward);
	}

	public void GetHit() {
		Reward();

		switch ( size ) {
			default:
				Vector2 velocity = rb.velocity;
				float _speed = velocity.magnitude;
				Vector2 dir = velocity.normalized;

				Vector2 dir2 = Vector3.Cross(dir, Vector3.forward);

				string tg = "MediumAsteroid";
				if ( size == AsteroidSize.Medium ) tg = "SmallAsteroid";


				GameObject prefab = PoolSpawner.instance.GetPrefab(tg);
				float radius = prefab.GetComponent<CircleCollider2D>().radius *
					prefab.transform.localScale.x;

				Asteroid asteroid1 = PoolSpawner.instance.InstantiateFromPool(tg,
					transform.position + (Vector3)dir2 * radius, Quaternion.identity).GetComponent<Asteroid>();

				Asteroid asteroid2 = PoolSpawner.instance.InstantiateFromPool(tg,
					transform.position - (Vector3)dir2 * radius, Quaternion.identity).GetComponent<Asteroid>();

				print("Spawns");

				Vector2 ast1Dir = (dir + dir2).normalized;
				Vector2 ast2Dir = (dir - dir2).normalized;

				asteroid1.Redirect(ast1Dir);
				asteroid2.Redirect(ast2Dir);

				break;
			case AsteroidSize.Small:
				break;
		}

		gameObject.SetActive(false);
	}

	public void Hit(IHitGetable target) {
		target.GetHit();
		gameObject.SetActive(false);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if ( collision.gameObject.tag == gameObject.tag ) return;
		IHitGetable target = collision.gameObject.GetComponent<IHitGetable>();
		if ( target != null ) Hit(target);
	}
}
