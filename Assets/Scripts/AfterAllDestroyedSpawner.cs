using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AfterAllDestroyedSpawner : MonoBehaviour
{
	public int count = 2;
	public int countPlus = 1;
	public float delay = 2;
	public string objectTag;
	public List<string> destroyedObjectsTags;

	bool can = true;

	[SerializeField] List<Transform> spawnPoints;

	List<GameObject> instances = new List<GameObject>();

	private void Start() {
		for (int i = 0; i < destroyedObjectsTags.Count; i++ ) {
			instances.AddRange(PoolSpawner.instance.GetAllInstances(destroyedObjectsTags[i]));
		}
	}

	private void Update() {
		if (can && AreAllDestroyed() ) {
			StartCoroutine(Spawn());
		}
	}

	IEnumerator Spawn() {
		can = false;
		yield return new WaitForSeconds(delay);
		for (int i = 0; i < count; i++ ) {
			Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Count)];
			PoolSpawner.instance.InstantiateFromPool(objectTag, spawn.position, spawn.rotation);
		}
		can = true;
		count += countPlus;
	}

	bool AreAllDestroyed() {
		for (int i = 0; i < instances.Count; i++ ) {
			if ( instances[i].activeSelf ) return false;
		}
		return true;
	}
}
