using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {

	public float coffee;
	public float collectionRate = 10.0f;
	public float consumeStudy = 10.0f;
	public float consumeHomework = 20.0f;

	// Use this for initialization
	void Start () {
//		GameObject user = GameObject.Find ("");

//		coffee = GetComponent<Coffee>;
	}
	
	// Update is called once per frame
	void Update () {
		//if user at coffee location
		//collectCoffee();


	}

	void collectCoffee(){
		coffee += collectionRate;
	}

	void consumeCoffee(int consumeType){
		if(consumeType == 1){
			coffee -= consumeStudy;
		}else if(consumeType == 2){
			coffee -= consumeHomework;
		}
	}
}
