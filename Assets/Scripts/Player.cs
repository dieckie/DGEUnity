using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject acorn;
	public float speed = 2f;
	public float cooldown = 2f;
	public float health = 20f;
	private bool _useGamepad;
		 
	private float sprintMultiplier;
	private Rigidbody2D rb;
	private DamageFlash flash;
	private float lastTime;

	void Start() {
		transform.position = new Vector3((Game.game - Game.width) / 2, transform.position.y, transform.position.z);
		rb = GetComponent<Rigidbody2D>();
		flash = GetComponent<DamageFlash>();
		lastTime = -50;
	}

	void Update() {

	}

	void FixedUpdate() {


		Debug.Log(_useGamepad);
		
		if(Input.GetButton("Jump") || Input.touchCount > 0) {
			if(Time.time - lastTime > cooldown) {
				GameObject newAcorn = Instantiate(acorn);
				newAcorn.transform.position = new Vector3(transform.position.x, transform.position.y);
				lastTime = Time.time;
			}
		}
		if(Input.GetButton("Sprint")) {
			sprintMultiplier = 2f;
		} else {
			sprintMultiplier = 1f;
		}
		if(Application.platform == RuntimePlatform.Android && !_useGamepad) {
			rb.velocity = new Vector2(Input.acceleration.x * speed * sprintMultiplier * 1.5f, rb.velocity.y);
		} else {
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * sprintMultiplier, rb.velocity.y);
		}
	}

	public void hurt(float damage) {
		health -= damage;
		flash.Flash();
		if(health <= 0) {
			Destroy(gameObject);
		}
	}

	public bool useGamepad {
		get{ return useGamepad; }
		set{ _useGamepad = value; }
	}


}
