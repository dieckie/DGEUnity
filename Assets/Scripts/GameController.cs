using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject floorPrefab;
	public GameObject upColliderPrefab;

	void Start () {
		GameObject colliders = new GameObject("Colliders");
		GameObject ground = new GameObject("Ground");
		for(int i = 0; i < 4; i++) {
			GameObject floor = Instantiate(floorPrefab);
			floor.transform.position = new Vector3(0f, -4.75f + i * 2.25f, 2f);
			floor.transform.parent = ground.transform;
			GameObject upCollider = Instantiate(upColliderPrefab);
			upCollider.transform.parent = colliders.transform;
			upCollider.transform.position = new Vector3((i % 2) * -17.4f + 8.7f, -4.4f + i * 2.25f, 2f);
		}
	}
}
