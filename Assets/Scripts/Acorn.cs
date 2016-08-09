using UnityEngine;
using System.Collections;
using Enemys;

public class Acorn : MonoBehaviour {

	public float speed;


	private Rigidbody2D rb;

	void Start() {

		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(0f, -speed);
	}

	void Update() {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col != null) {
			if (col.CompareTag("Enemy")) {
			    SimpleEnemy enemy = col.GetComponent<SimpleEnemy>();
				if(enemy != null) {
					enemy.Damage(1);
					Destroy(gameObject);
				}

			}
		}
	}
}
