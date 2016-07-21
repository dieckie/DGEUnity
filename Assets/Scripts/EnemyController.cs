using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

	public Color hurtColor;
	public float rampUpTime = 0.1f;
	public float holdTime = 0f;
	public float rampDownTime = 0.4f;

	public int health = 10;
	public float speed = 1f;
	public float jump = 1f;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Color enemyCol;
	private float direction = -1f;
	private bool up = false;

	void Start() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		enemyCol = sr.color;
	}

	void FixedUpdate() {
		if(!up) {
			rb.velocity = new Vector2(speed * direction, 0f);
		}
	}

	void Update() {
		switch(state) {
		case FLASHSTATE.UP:
			sr.color = Color.Lerp(enemyCol, hurtColor, timer.Elapsed);
			if(timer.UpdateAndTest()) {
				state = FLASHSTATE.HOLD;
				timer = new Timer(holdTime);
			}
			break;
		case FLASHSTATE.HOLD:
			if(timer.UpdateAndTest()) {
				state = FLASHSTATE.DOWN;
				timer = new Timer(rampDownTime);
			}
			break;
		case FLASHSTATE.DOWN:
			sr.color = Color.Lerp(hurtColor, enemyCol, timer.Elapsed);
			if(timer.UpdateAndTest()) {
				state = FLASHSTATE.OFF;
				timer = null;
			}
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("ColUp")) {
			up = true;
			rb.velocity = new Vector2(0f, jump);
		} else if (col.CompareTag("Floor")) {
			if (rb.velocity.y <= 0) {
				up = false;
				direction *= -1;
			}
		} else if (col.CompareTag("Player")) {
			col.gameObject.GetComponent<PlayerController>().hurt();
		}
	}

	public void Damage(int damage) {
		health -= damage;
		Flash();
		if(health <= 0) {
			GetComponentInParent<Spawner>().Respawn();
			Destroy(gameObject);
		}
	}

	enum FLASHSTATE {
		OFF,
		UP,
		HOLD,
		DOWN
	}

	Timer timer;
	FLASHSTATE state = FLASHSTATE.OFF;

	public void Flash() {
		timer = new Timer(rampUpTime);
		state = FLASHSTATE.UP;
	}
}
