using UnityEngine;
using System.Collections;

public class grads : MonoBehaviour {

//	public Camera mainCam;
//	
//	private GameObject newStudent;
//	
//	//private StudentData studentData; 
//	private Names names;
//	private Taglines taglines;
//	private Majors majors;
//	
//	//arrays of all available student graphics
//	public GameObject[] bodies;
//	public GameObject[] heads;
//	public GameObject[] clothes;
//	public GameObject[] hairs;
//	
//	private GameObject newBody;
//	private GameObject newHead;
//	private GameObject newClothes;
//	private GameObject newHair;
//	
//	Vector3 spawnPoint;
//	
//	private int rand;
//	private int count = 0;
//	
//	private GameObject CollectStudent;
//	
//	private int studentCount = 0;
//	float lastTime = 0;
//	
//	public bool first = true;
//
	GameObject gradList;
	
	
	// Use this for initialization
	void Start()
	{		

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (!GameObject.Find ("SettingsMenu(Clone)") && !GameObject.Find ("Popup(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gradList(Clone)") && !GameObject.Find ("gratzPop(Clone)") && !GameObject.Find ("TutorialBox(Clone)") ) {
			gradList = Instantiate (Resources.Load ("gradList")) as GameObject;
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
		}
	}
}
