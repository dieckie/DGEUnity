using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy;

	void Start() {
		Respawn();
	}

	public void Respawn() {
		GameObject e = Instantiate(enemy);
		e.transform.parent = transform;
	}
}
