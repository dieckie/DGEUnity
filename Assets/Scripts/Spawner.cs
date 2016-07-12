using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy;

	void Start () {
		Respawn();
	}

	public void Respawn() {
		Instantiate(enemy).transform.parent = transform;
	}
}
