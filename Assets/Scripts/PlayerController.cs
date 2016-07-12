using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject acorn;
	public float speed = 2f;
	public float cooldown = 2f;
	 
	private float sprintMultiplier;
	private Rigidbody2D rb;
	private float lastTime;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		lastTime = -50;
	}

	void Update() {

	}

	void FixedUpdate() {
		if (Input.GetButton("Jump")) {
			if (Time.time - lastTime > cooldown) {
				GameObject newAcorn = Instantiate(acorn);
				newAcorn.transform.position = new Vector3(transform.position.x, transform.position.y);
				lastTime = Time.time;
			}
		}
		
		if (Input.GetButton("Sprint")) {
			sprintMultiplier = 2f;
		} else {
			sprintMultiplier = 1f;
		}
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * sprintMultiplier, rb.velocity.y);
	}

}
