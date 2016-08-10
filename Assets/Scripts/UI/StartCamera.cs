using UnityEngine;
using System.Collections;

public class StartCamera : MonoBehaviour {


	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		
		if(transform.rotation.x > -0.1) {
			transform.Rotate(new Vector2(-0.1f, 0));

		}
	}
}
