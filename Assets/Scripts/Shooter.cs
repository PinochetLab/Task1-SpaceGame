using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] string bulletName;
	[SerializeField] Transform placeForInstantiate;
	[SerializeField] float shootsInSecond = 3f;

	float period;
	public bool automatic = false;
	float time = 0;

	private void Start() {
		period = 1f / shootsInSecond;
	}

	private void Update() {
		time += Time.deltaTime;
		if ( automatic ) TryShoot();
	}

	public void TryShoot() {
		if (time > period ) {
			time = 0;
			Shoot();
		}
	}

	void Shoot() {
		GameObject _bullet = PoolSpawner.instance.InstantiateFromPool(bulletName, placeForInstantiate.position, placeForInstantiate.rotation);
		_bullet.tag = gameObject.tag;
	}

}
