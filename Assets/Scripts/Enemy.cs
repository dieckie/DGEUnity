using UnityEngine;
using System.Collections;


public abstract class Enemy : MonoBehaviour {
	public float maxHealth=10f;
	public float speed = 1f;
	public int difficulty=1;
	public float damage=1f;


	internal GameObject player;
	internal Rigidbody2D rb;
	internal float direction = -1f;
	internal bool up = false;
	internal float health;
	internal float jump = 7f;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		player = GameObject.FindGameObjectWithTag("Player");
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Movement();

	}

	void Movement(){
		if(!up) {
			rb.velocity = new Vector2(speed * direction, 0f);
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
			col.gameObject.GetComponent<Player>().hurt(damage);
		}
	}

	public void Damage(int damage) {
		health -= damage;
		if(health <= 0) {
			Coin.AddCoins(1);
			GetComponentInParent<Spawner>().Respawn();
			Destroy(gameObject);
		}
	}

	public float getHealth() {
		return health;
	}
}