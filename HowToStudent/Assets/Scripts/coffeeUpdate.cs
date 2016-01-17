using UnityEngine;
using System.Collections;

public class coffeeUpdate : MonoBehaviour {

	private Coffee coffeeThings;
	float coffeeBar;

	// Use this for initialization
	void Start () {
		coffeeThings = GameObject.Find ("playerDot").GetComponent<Coffee> ();
	}
	
	// Update is called once per frame
	void Update () {
		coffeeBar = coffeeThings.coffee;
		coffeeBar = (coffeeBar - 0) / (100 - 0) * (4 - 0) + 0;
		gameObject.transform.localScale = new Vector3 (coffeeBar, 4.0f, 4.0f);
	}
}
