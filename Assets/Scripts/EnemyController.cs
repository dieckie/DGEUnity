using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

	public GameObject player;
	public Color hurtColor;
	public int health = 10;
	public float hurtCooldown = 0.5f;
	public float speed = 1f;
	public float jump = 1f;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Color enemyCol;
	private float direction = -1f;
	private bool up = false;

	private float lastHurt = 0;
	private bool hurtSprite = false;



	void Start() {
		//Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
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
		if(hurtSprite) {
			if(Time.time - lastHurt > hurtCooldown) {
				sr.color = enemyCol;
				hurtSprite = false;
			}
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
			Debug.Log(Analytics.CustomEvent("gameOver", new Dictionary<string, object>{}));
			Destroy(col.gameObject);
		}
	}

	public void Damage(int damage) {
		health -= damage;
		hurtSprite = true;
		sr.color = hurtColor;
		lastHurt = Time.time;
		if(health <= 0) {
			GetComponentInParent<Spawner>().Respawn();
			Destroy(gameObject);
		}
	}
}
