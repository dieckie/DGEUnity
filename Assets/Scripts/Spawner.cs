using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public List<GameObject> enemys = new List<GameObject>();

	void Start() {
		Respawn();
	}

	public void Respawn() {
		GameObject e = Instantiate(enemys[0]);
		e.transform.parent = transform;
	}
}
