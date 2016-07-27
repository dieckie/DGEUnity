using UnityEngine;
using System.Collections;

public class Timer {
	float _timeElapsed;
	float _totalTime;

	public Timer(float timeToCountInSec) {
		_totalTime = timeToCountInSec;

	}

	public bool UpdateAndTest() {
		_timeElapsed += Time.deltaTime;
		return _timeElapsed >= _totalTime;
	}

	public float Elapsed {
		get { return Mathf.Clamp(_timeElapsed / _totalTime, 0, 1); }
	}
}