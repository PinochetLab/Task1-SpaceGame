using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
	public string tag;
	public GameObject prefab;
	public int count;
}

public class PoolSpawner : MonoBehaviour
{
	public List<Pool> pools;
	public static PoolSpawner instance;
	public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

	void SetObjectPool() {
		foreach (Pool pool in pools ) {
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for (int i = 0; i < pool.count; i++ ) {
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}

			poolDictionary.Add(pool.tag, objectPool);
		}
	}

	private void Awake() {
		instance = this;
		SetObjectPool();
	}

	public GameObject InstantiateFromPool(string _tag, Vector3 position, Quaternion rotation) {
		if ( !poolDictionary.ContainsKey(_tag) ) return null;
		GameObject obj = poolDictionary[_tag].Dequeue();
		obj.SetActive(true);
		obj.transform.SetPositionAndRotation(position, rotation);
		poolDictionary[_tag].Enqueue(obj);
		return obj;
	}

	public List<GameObject> GetAllInstances(string _tag) {

		if ( !poolDictionary.ContainsKey(_tag) ) return null;
		Queue<GameObject> gameObjects = poolDictionary[_tag];

		List<GameObject> res = new List<GameObject>();

		for (int i = 0; i < gameObjects.Count; i++ ) {
			GameObject obj = gameObjects.Dequeue();
			res.Add(obj);
			gameObjects.Enqueue(obj);
		}

		return res;
	}

	public GameObject GetPrefab(string _tag) {
		return pools.Find(x => x.tag == _tag).prefab;
	}

	public void DeactivateAll() {
		foreach (var queue in poolDictionary ) {
			Queue<GameObject> q = queue.Value;
			GameObject obj = q.Dequeue();
			obj.SetActive(false);
			q.Enqueue(obj);
		}
	}
}
