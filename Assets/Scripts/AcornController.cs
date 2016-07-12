using UnityEngine;
using System.Collections;

public class AcornController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(0f, - speed);
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(col.gameObject);
	}
}
