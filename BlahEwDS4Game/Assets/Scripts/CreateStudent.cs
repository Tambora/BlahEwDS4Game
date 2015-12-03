using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateStudent : MonoBehaviour {

    public Camera mainCam;
    
    private GameObject newStudent;
    private List<GameObject> students;

    //private StudentData studentData; 
    private Names names;
    private Taglines taglines;
    private Majors majors;

    //arrays of all available student graphics
    public GameObject[] bodies;
    public GameObject[] heads;
    public GameObject[] clothes;
    public GameObject[] hairs;

    private GameObject newBody;
    private GameObject newHead;
    private GameObject newClothes;
    private GameObject newHair;

    Vector3 spawnPoint;

    private int rand;
    private int count = 0;

	// Use this for initialization
	void Start () {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        students = new List<GameObject>();

        names = GetComponent<Names>();
        taglines = GetComponent<Taglines>();
        majors = GetComponent<Majors>();

        //load character parts from resources folder into arrays
        bodies = System.Array.ConvertAll( Resources.LoadAll("Bodies", typeof(GameObject)),o=>(GameObject)o);
        heads = System.Array.ConvertAll(Resources.LoadAll("Heads", typeof(GameObject)), o => (GameObject)o);
        clothes = System.Array.ConvertAll(Resources.LoadAll("Clothes", typeof(GameObject)), o => (GameObject)o);
        hairs = System.Array.ConvertAll(Resources.LoadAll("Hairs", typeof(GameObject)), o => (GameObject)o);

	}
	
	// Update is called once per frame
	void Update () {
        //for testing delete later
        /*for (int i = 0; i < students.Count; i++ )
        {
            print(students[i].GetComponent<StudentData>().tagline);
        }*/
	}

    //Currently students are created by clicking the box in the scene - when ready move code below to whatever function is called when player finds a student
    void OnMouseDown()
    {	

        newStudent = new GameObject("Student" + count);
        count++;

        //get a random number for body+head so they match
        rand = Random.Range(0, bodies.Length);

        //instantiate random body/head/hair/clothes and parent under new Student GameObject
        newHair = Instantiate(hairs[Random.Range(0, hairs.Length)]);
        newHair.transform.parent = newStudent.transform;

        newHead = Instantiate(heads[rand]);
        newHead.transform.parent = newStudent.transform;

        newClothes = Instantiate(clothes[Random.Range(0, clothes.Length)]);
        newClothes.transform.parent = newStudent.transform;

        newBody = Instantiate(bodies[rand]);
        newBody.transform.parent = newStudent.transform;

        //add StudentData script to track variables
        StudentData newData = newStudent.AddComponent<StudentData>();

        //add name + tagline + major
        newData.name = names.getName();
        newData.tagline = taglines.getTagline(0);   //0 corresponds to a location so we can have location specific tags, modify as needed to tie in with location script
        newData.major = majors.getMajor();

        newStudent.AddComponent<BoxCollider2D>();       	
		newStudent.GetComponent<BoxCollider2D> ().isTrigger = true;

		newStudent.AddComponent<showPopup>();

        //set spawn position
        spawnPoint = mainCam.ScreenToWorldPoint(new Vector3(Random.Range(50, Screen.width-50), Random.Range(200, Screen.height-30), mainCam.nearClipPlane));
        newStudent.transform.Translate(spawnPoint);

        //add Student tag to game object
        newStudent.tag = "Student";

        //add student to students array
        students.Add(newStudent);

    }
}
