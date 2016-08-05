using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject acorn;
	public float speed = 2f;
	public float cooldown = 2f;
	 
	private float sprintMultiplier;
	private Rigidbody2D rb;
	private DamageFlashController flash;
	private float lastTime;

	void Start() {
		transform.position = new Vector3((GameController.game - GameController.width) / 2, transform.position.y, transform.position.z);
		rb = GetComponent<Rigidbody2D>();
		flash = GetComponent<DamageFlashController>();
		lastTime = -50;
	}

	void Update() {

	}

	void FixedUpdate() {
		
		if (Input.GetButton("Jump") || Input.touchCount > 0) {
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
		if(Application.platform == RuntimePlatform.Android) {
			rb.velocity = new Vector2(Input.acceleration.x * speed * sprintMultiplier, rb.velocity.y);
		} else {
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * sprintMultiplier, rb.velocity.y);
		}
	}

	public void hurt() {
		flash.Flash();
	}

}
