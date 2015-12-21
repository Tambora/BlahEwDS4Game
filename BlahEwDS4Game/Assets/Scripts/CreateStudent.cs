using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateStudent : MonoBehaviour {

    public Camera mainCam;
    
    private GameObject newStudent;
    public List<GameObject> students;

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

    private int count = 0;

    private GameObject CollectStudent;

    private int studentCount = 0;
    float lastTime = 0;

    public bool first = true;

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

        if( Time.time - lastTime > 100)
        {
            SpawnStudent();
            lastTime = Time.time;
        }

//        print(Time.time);

	}

    //Currently students are created by clicking the box in the scene - when ready move code below to whatever function is called when player finds a student
    public void SpawnStudent()
    {	
		if (!GameObject.Find ("Popup(Clone)") && !GameObject.Find ("Map(Clone)") && !GameObject.Find ("SettingsMenu(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gradList(Clone)") && !GameObject.Find ("gratzPop(Clone)")   ) {
			newStudent = new GameObject ("Student" + count);

			//get a random number for body+head so they match
			int heabodies = Random.Range (0, bodies.Length);
			int hair = Random.Range (0, hairs.Length);
			int clothess = Random.Range (0, clothes.Length);

			//instantiate random body/head/hair/clothes and parent under new Student GameObject
			newHair = Instantiate (hairs [hair]);
			newHair.transform.parent = newStudent.transform;

			newHead = Instantiate (heads [heabodies]);
			newHead.transform.parent = newStudent.transform;

			newClothes = Instantiate (clothes [clothess]);
			newClothes.transform.parent = newStudent.transform;

			newBody = Instantiate (bodies [heabodies]);
			newBody.transform.parent = newStudent.transform;

			PlayerPrefs.SetInt ("Student" + count + " head", heabodies);
			PlayerPrefs.SetInt ("Student" + count + " hair", hair);
			PlayerPrefs.SetInt ("Student" + count + " clothes", clothess);
			PlayerPrefs.SetInt ("Count", count);

			//add StudentData script to track variables
			StudentData newData = newStudent.AddComponent<StudentData> ();

			//add name + tagline + major
			newData.name = names.getName ();
			newData.tagline = taglines.getTagline (0);   //0 corresponds to a location so we can have location specific tags, modify as needed to tie in with location script
			newData.major = majors.getMajor ();

			newStudent.AddComponent<BoxCollider2D> ();       	
			newStudent.GetComponent<BoxCollider2D> ().isTrigger = true;
			newStudent.GetComponent<BoxCollider2D> ().size = new Vector2 (0.25f, 0.25f);
			newStudent.AddComponent<showPopup> ();   

			//Random GPA and timeStuff
			newData.CGPA = Random.Range (6.0f, 10.0f);
			
			System.DateTime epochStart = new System.DateTime (1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
			int timeNow = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
			newData.lastUpdate = timeNow;
			newData.studyStart = timeNow - 3600 * 8 - 1;
			newData.hwStart = timeNow - 3600 * 3 - 1;
			
			newData.enrollSemester = (int)(timeNow / 3);
			newData.currentSemester = 0;

			//set spawn position
			//spawnPoint = mainCam.ScreenToWorldPoint(new Vector3(Random.Range(50, Screen.width-50), Random.Range(200, Screen.height-30), 1));
			spawnPoint = new Vector3 (0f, 1.36f, 0f);
			newStudent.transform.Translate (spawnPoint);
			newStudent.transform.localScale += new Vector3 (1.5f, 1.5f, 1.5f);

			//add Student tag to game object
			newStudent.tag = "Student";
	        
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[3].Play();

			CollectStudent = Instantiate (Resources.Load ("EncounterBox")) as GameObject;
			CollectStudent.GetComponentsInChildren<TextMesh> () [0].text = newData.name;
			CollectStudent.GetComponentsInChildren<TextMesh> () [1].text = newData.major;
			CollectStudent.GetComponentsInChildren<TextMesh> () [2].text = "'" + newData.tagline + "'";
		}

    }

    public void keepStudent( GameObject popup )
    {
        students.Add(newStudent);
        newStudent.transform.Translate(0, -1.36f, 0);
		int spawnX = Random.Range(50, Screen.width - 50);
		int spawnY = Random.Range(100, Screen.height - 100);
		spawnPoint = mainCam.ScreenToWorldPoint(new Vector3(spawnX, spawnY, 1));

		PlayerPrefs.SetFloat("Student"+count+" spawnX", spawnX);
		PlayerPrefs.SetFloat("Student"+count+" spawnY", spawnY);
		PlayerPrefs.Save();

        newStudent.transform.Translate(spawnPoint);

        newHair.GetComponent<Renderer>().sortingLayerName = "Main";
        newHair.GetComponent<Renderer>().sortingOrder = 1;
        newHead.GetComponent<Renderer>().sortingLayerName = "Main";
        newClothes.GetComponent<Renderer>().sortingLayerName = "Main";
        newClothes.GetComponent<Renderer>().sortingOrder = 1;
        newBody.GetComponent<Renderer>().sortingLayerName = "Main";
		count++;

        Destroy(popup);
    }

    public void dismissStudent( GameObject popup )
    {
        Destroy(newStudent);
        Destroy(popup);
    }
}
