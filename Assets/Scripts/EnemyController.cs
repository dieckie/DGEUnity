using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 1f;

	private float direction = 1f;
	private float speedXMul = 1f;
	private bool up = false;

	void Start() {
	
	}

	void Update() {
	
	}

	void FixedUpdate() {
		if(up) {
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, 2f);
		} else {
			transform.position = new Vector3(transform.position.x + speed * speedXMul * direction, transform.position.y, 2f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("ColUp")) {
			up = true;
			Debug.Log("ColUp: " + up);
		} else if(col.CompareTag("ColSide")) {
			up = false;
			direction *= -1;
			Debug.Log("ColUp: " + up);
		}
	}
}
