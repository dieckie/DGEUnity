﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Enemys;


	public class Spawner : MonoBehaviour {

	public List<EnemyDiff> enemys = new List<EnemyDiff>();
	public int difficulty = 1;

	public Text waveText;

	public float staticPuffer = 1f;
	public float dynamicPuffer = 1f;

	private List<Enemy> queue = new List<Enemy>();

	private float nextTime;
	private int livingEnemys = 0;
	private int wave = 0;

	void Start() {
		NextWave();
	}



	void Update() {
		if(Time.time > nextTime) {
			if(queue.Count > 0) {
				Enemy enemy = Instantiate(queue[0]);
				enemy.transform.parent = transform;
				livingEnemys++;
				queue.RemoveAt(0);
				nextTime = Time.time + GetRndTime();
			}
		}
	}

	private void NextWave() {
		wave++;
		MakeList();
		difficulty = wave + wave;
		nextTime = Time.time;
		waveText.text = "Wave: " + wave;
	}

	public void EnemyDied() {
		livingEnemys--;
		if(livingEnemys == 0) {
			difficulty++;
			NextWave();
		}
	}

	private float GetRndTime() {
		return staticPuffer + Random.value * dynamicPuffer;
	}

	public void MakeList() {
		int diff = difficulty;
		List<EnemyDiff> remaindingEnemys = new List<EnemyDiff>(enemys);
		while(diff > 0 && remaindingEnemys.Count > 0) {
			int rnd = Random.Range(0, remaindingEnemys.Count);
			if(remaindingEnemys[rnd].diff <= diff) {
				queue.Add(remaindingEnemys[rnd].e);
				diff -= remaindingEnemys[rnd].diff;
			} else {
				remaindingEnemys.RemoveAt(rnd);
			}
		}
	}

	public void AddEnemy(int amount){
		livingEnemys += amount;
	}
}