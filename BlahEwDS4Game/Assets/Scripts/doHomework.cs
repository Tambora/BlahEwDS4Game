using UnityEngine;
using System.Collections;

public class doHomework : MonoBehaviour {

	StudentData hwStudent;
	private Coffee coffeeThings;
	showPopup popup;
	main mainSelected;
	int systemTime;
	System.DateTime epochStart;

	// Use this for initialization
	void Start () {
		mainSelected = GameObject.Find ("QUAD").GetComponent<main> ();
		coffeeThings = GameObject.Find ("playerDot").GetComponent<Coffee> ();
		epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
	}
	
	// Update is called once per frame
	void Update () {
		systemTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
	}

	void OnMouseDown(){
		Debug.Log (mainSelected.selectedStudent);
		hwStudent = GameObject.Find (mainSelected.selectedStudent).GetComponent<StudentData> ();
		if (hwStudent.studentState == 0) {
			hwStudent.hwStart = systemTime;
			hwStudent.studentState = 2;
			coffeeThings.coffee -= 12;
			Debug.Log (coffeeThings.coffee);
		}
	}
}
