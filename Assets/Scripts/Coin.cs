using UnityEngine;
using System.Collections;

public static class Coin {




	// Use this for initialization
	 public static void Init() {
		//Debug
		PlayerPrefs.SetInt("coins", 0);
	}


			


	public static int GetCoins(){
		return PlayerPrefs.GetInt("coins");
	}

	public static void SetCoins(int coins){
		PlayerPrefs.SetInt("coins", coins);
	}

	public static void AddCoins(int coins){
		PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+coins);
	}

	public static void RemoveCoins(int coins){
		PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")-coins);
	}
}
