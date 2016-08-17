using UnityEngine;
using System.Collections;

namespace Enemys {
	public class SpawnerEnemy : Enemy {
		public float interval = 8f;
		public GameObject Enemy;

		private float nextTime;
		// Use this for initialization
		void Start() {
			//TODO das ändern
			base.Start();
			nextTime = interval;
		}
	
		// Update is called once per frame
		void Update() {
			
			if(Time.time > nextTime) {
				SpawnEnemy();
				GetComponentInParent<Spawner>().AddEnemy(1);
				nextTime = Time.time + interval;
			
			}
		}

		void SpawnEnemy() {
			Instantiate(Enemy, transform.position, transform.rotation, transform.parent);
			
		}
	}
}