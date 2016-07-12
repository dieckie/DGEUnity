using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speed = 2f;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void  FixedUpdate(){
		rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, 0f);
	}

}
