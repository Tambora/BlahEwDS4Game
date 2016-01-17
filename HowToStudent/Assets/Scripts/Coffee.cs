using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {

	public int coffee = 50;
	public int coffeeMax = 100;
	public int collectionRate = 1;

	// Use this for initialization
	void Start () {
//		GameObject user = GameObject.Find ("");
		//Debug.Log (coffee);
//		coffee = GetComponent<Coffee>;
	}
	
	// Update is called once per frame
	void Update () {
		//if user at coffee location
		//collectCoffee();


	}

	public void collectCoffee(){
		coffee += collectionRate;
	}
}
