using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Vector2 size;
	public float offset;

	private Enemy e;

	private float max;
	private float health;
	private Texture2D redBar;

	// Use this for initialization
	void Start() {
		e = GetComponent<Enemy>();
		max = e.maxHealth;
		health = max;

		redBar = (Texture2D)Resources.Load("Texture/UI/Red2");
	}
	
	// Update is called once per frame
	void Update() {
		health = e.getHealth();

	}

	void OnGUI(){
		Vector3 pos1 = new Vector3(transform.position.x, transform.position.y * -1);
		Vector3 pos = Camera.main.WorldToScreenPoint(pos1);
		float x = pos.x;
		float y = pos.y + offset;
		float urx = x - size.x / 2;
		float ury = y - size.y / 2;

		GUI.Box(new Rect(new Vector2(urx, ury), size),"");

		GUI.DrawTextureWithTexCoords(new Rect(new Vector2(urx + 1, ury + 1), new Vector2((size.x - 2) * health / max, size.y - 2)), redBar, new Rect(24f / 50, 24f / 50, 2f / 50, 2f / 50));
	}

}
