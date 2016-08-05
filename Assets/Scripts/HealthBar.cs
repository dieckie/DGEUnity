using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Vector2 size;
	public float offset;


	private Texture2D redBar;
	private Texture2D greenBar;
	// Use this for initialization
	void Start() {
		
		redBar = (Texture2D)Resources.Load("Texture/UI/Red2");

		greenBar = (Texture2D)Resources.Load("Texture/UI/Green");	
	}
	
	// Update is called once per frame
	void Update() {
		

	}

	void OnGUI(){
		Vector3 pos1 = new Vector3(transform.position.x, transform.position.y * -1);
		Vector3 pos = Camera.main.WorldToScreenPoint(pos1);
		float x = pos.x;
		float y = pos.y + offset;
		float urx = x - size.x / 2;
		float ury = y - size.y / 2;

		GUI.Box(new Rect(new Vector2(urx, ury), size),"");

		GUI.DrawTextureWithTexCoords(new Rect(new Vector2(urx+1, ury+1), new Vector2(size.x-2, size.y-2)), redBar, new Rect(24f / 50, 24f / 50, 2f / 50, 2f / 50));
	}
}
