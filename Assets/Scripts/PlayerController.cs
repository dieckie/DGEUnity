using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speedMultiplier;

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  FixedUpdate(){

		rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speedMultiplier, 0f));

	}

}
