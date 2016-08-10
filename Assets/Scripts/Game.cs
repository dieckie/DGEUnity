using UnityEngine;
using System.Collections;


public class Game : MonoBehaviour {

	public GameObject floorPrefab;
	public GameObject upColliderPrefab;
	public GameObject sideColliderPrefab;
	public GameObject killBorder;

	public static float height, width, game;

	void Start() {
		Coin.Init();
		Camera cam = Camera.main;
		Game.height = 2f * cam.orthographicSize;
		Game.width = Game.height * cam.aspect;
		Game.game = 12f;
		//float shopBorder = -0.5f * GameController.width + GameController.game;
		float gameMiddle = (Game.game - Game.width) * 0.5f;

		GameObject colliders = new GameObject("Colliders");
		GameObject ground = new GameObject("Ground");
		for(int i = 0; i < 4; i++) {
			GameObject floor = Instantiate(floorPrefab);
			floor.transform.position = new Vector3(gameMiddle, -4.86f + i * 2.25f, 2f);
			floor.transform.parent = ground.transform;
			if(i != 3) {
				GameObject upCollider = Instantiate(upColliderPrefab);
				upCollider.transform.parent = colliders.transform;
				upCollider.transform.position = new Vector3(gameMiddle + (i % 2) * -game + game / 2, -4.4f + i * 2.25f, 2f);
			}
			if(i != 0) {
				GameObject sideCollider = Instantiate(sideColliderPrefab);
				sideCollider.transform.parent = colliders.transform;
				sideCollider.transform.position = new Vector3(gameMiddle + ((i + 1) % 2) * (-game + 1) + (game - 1) / 2, -4.82f + i * 2.25f, 2f);
			}
		}
		GameObject sideColliderTop = Instantiate(sideColliderPrefab);
		sideColliderTop.transform.parent = colliders.transform;
		sideColliderTop.transform.position = new Vector3(gameMiddle + (-game + 1) / 2, -4.4f + 6.75f, 2f);

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

	void Update() {
		if(Input.GetButton("Cancel")) {
			Application.Quit();
		}
		if(Input.GetKey(KeyCode.S)) {

			Debug.Log(PlayerPrefs.GetInt("coins") + "");
			PlayerPrefs.Save();		
		}
	}
}
