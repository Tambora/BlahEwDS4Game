using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class grads : MonoBehaviour {


	GameObject gradList;
	List<string> gradNames = new List<string>();
	private GameObject gradBox;
	
	// Use this for initialization
	void Start()
	{		

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (!GameObject.Find ("gradList(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gratzPop(Clone)") && !GameObject.Find ("SettingsMenu(Clone)") ) {
			gradList = Instantiate (Resources.Load ("gradList")) as GameObject;
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();

			//Get the list of grads

			for(int i=0; PlayerPrefs.HasKey("Student"+i+" (UnityEngine.GameObject) name"); i++) {
				if (PlayerPrefs.GetInt("Student"+i+" (UnityEngine.GameObject) studentState") == 4) {

					gradNames.Add(PlayerPrefs.GetString("Student"+i+" (UnityEngine.GameObject) name"));
					gradBox = Instantiate (Resources.Load ("Popup"))as GameObject;
					// pull up a grad box per student, x = 2-y*1.7
					// Shove all that in a game object, and shove that in a scroll rect
					// ???
					// Profit
				
				}
			}


			//Display the list of grads
			Debug.Log(gradNames[0]);
		}
	}
}
