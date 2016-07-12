using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject acorn;
	public float speed = 2f;

private float sprintMultiplier;
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {

	}

	void FixedUpdate() {
		if(Input.GetButton("Fire1")) {
			GameObject newAcorn = Instantiate(acorn);
			newAcorn.transform.position = new Vector3(transform.position.x, newAcorn.transform.position.y);

		}
		
		if(Input.GetButton("Sprint")){
			sprintMultiplier=2f;
		}else{
			sprintMultiplier=1f;
		}
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * sprintMultiplier, rb.velocity.y);
	}

}
