using UnityEngine;
using System.Collections;

public class mapScroll : MonoBehaviour {

	float initialX;
	bool dragging = false;
	main mainVar;
	float translateX = 0;

	// Use this for initialization
	void Start () {
		mainVar = GameObject.Find ("QUAD").GetComponent<main> ();
//		Debug.Log ("started DRAGGING");
	}
	
	// Update is called once per frame
//	void Update () {
//
//	}

	void OnMouseDrag(){
//		transform.position = new Vector2 (transform.position.x, transform.position.y);
		if (!dragging) {
			initialX = Input.mousePosition.x;
			dragging = true;
		}
		if (Input.mousePosition.x < initialX && transform.position.x < 1.56) {
//			transform.position = new Vector2 (transform.position.x + 0.05f, transform.position.y);
//			if(translateX < 0){
//				translateX = 0;
//			}
			translateX = transform.position.x + 0.05f;
			transform.position = new Vector2 (translateX, transform.position.y);
			mainVar.scrollDistance = translateX;
//			GameObject.Find("playerDot").transform.position = new Vector2 (GameObject.Find("playerDot").transform.position.x + 0.05f, GameObject.Find("playerDot").transform.position.y);
		} else if (Input.mousePosition.x > initialX  && transform.position.x > -1.56) {
//			transform.position = new Vector2 (transform.position.x - 0.05f, transform.position.y);
//			if(translateX > 0){
//				translateX = 0;
//			}
			translateX = transform.position.x - 0.05f;
			transform.position = new Vector2 (translateX, transform.position.y);
			mainVar.scrollDistance = translateX;
//			GameObject.Find("playerDot").transform.position = new Vector2 (GameObject.Find("playerDot").transform.position.x - 0.05f, GameObject.Find("playerDot").transform.position.y);
		}
//		transform.position = new Vector2 (translateX, transform.position.y);
		Debug.Log (translateX);

	}

	void OnMouseUp(){
		dragging = false;
	}
}
