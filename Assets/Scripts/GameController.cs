using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject floorPrefab;
	public GameObject upColliderPrefab;
	public GameObject killBorder;

	private float height, width, game;

	void Start() {
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		game = 12f;
		GameObject colliders = new GameObject("Colliders");
		GameObject ground = new GameObject("Ground");
		for(int i = 0; i < 4; i++) {
			GameObject floor = Instantiate(floorPrefab);
			floor.transform.position = new Vector3(0f, -4.75f + i * 2.25f, 2f);
			floor.transform.parent = ground.transform;
			GameObject upCollider = Instantiate(upColliderPrefab);
			upCollider.transform.parent = colliders.transform;
			//upCollider.transform.position = new Vector3((i % 2) * -17.4f + 8.7f, -4.4f + i * 2.25f, 2f);
			upCollider.transform.position = new Vector3((i % 2) * (-width + 1) + (width - 1) / 2, -4.4f + i * 2.25f, 2f);
		}
		GameObject bottom = Instantiate(killBorder);
		bottom.transform.parent = colliders.transform;
		bottom.transform.position = new Vector3(0f, -8f);
		GameObject top = Instantiate(killBorder);
		top.transform.parent = colliders.transform;
		top.transform.position = new Vector3(0f, 8f);
		GameObject left = Instantiate(killBorder);
		left.transform.parent = colliders.transform;
		left.transform.position = new Vector3(-12f, 0f);
		left.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
		GameObject right = Instantiate(killBorder);
		right.transform.parent = colliders.transform;
		right.transform.position = new Vector3(12f, 0f);
		right.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
	}

	void OnDrawGizmos() {
		float x = width / 2 - (width - game);
		Gizmos.DrawLine(new Vector3(x, -height), new Vector3(x, height));
	}
           void FixedUpdate() {
		if (Input.GetButton("Back")) {
			Application.Exit();
			}
		}
}
