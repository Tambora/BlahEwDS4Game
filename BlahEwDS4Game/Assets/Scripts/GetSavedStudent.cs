using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetSavedStudent : MonoBehaviour {

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

    private int rand;
    private int count = 0;

    private GameObject CollectStudent;

    private int studentCount = 0;
    float lastTime = 0;

    public bool first = true;

    CreateStudent createStudent;

    // Use this for initialization
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        createStudent = GameObject.Find("GameObject").GetComponent<CreateStudent>();

        students = new List<GameObject>();

        names = GetComponent<Names>();
        taglines = GetComponent<Taglines>();
        majors = GetComponent<Majors>();

        //load character parts from resources folder into arrays
        bodies = System.Array.ConvertAll(Resources.LoadAll("Bodies", typeof(GameObject)), o => (GameObject)o);
        heads = System.Array.ConvertAll(Resources.LoadAll("Heads", typeof(GameObject)), o => (GameObject)o);
        clothes = System.Array.ConvertAll(Resources.LoadAll("Clothes", typeof(GameObject)), o => (GameObject)o);
        hairs = System.Array.ConvertAll(Resources.LoadAll("Hairs", typeof(GameObject)), o => (GameObject)o);

        createStudent.count = PlayerPrefs.GetInt("Count");
        for (int i = 0; i < createStudent.count; i++)
        {
            int state = PlayerPrefs.GetInt("Student0 studentState");
            print("studentState " + state);

            if (state != 3)
            {
                print("k");
                //get sprite vars
                int head = PlayerPrefs.GetInt("Student" + i + " head");
                int clothing = PlayerPrefs.GetInt("Student" + i + " clothes");
                int hair = PlayerPrefs.GetInt("Student" + i + " hair");

                //get student gen vars
                string name = PlayerPrefs.GetString("Student" + i + " name");
                string tagline = PlayerPrefs.GetString("Student" + i + " tagline");
                string major = PlayerPrefs.GetString("Student" + i + " major");

                //get gameVars
                float CGPA = PlayerPrefs.GetFloat("Student" + i + " CGPA");
                float posX = PlayerPrefs.GetFloat("Student" + i + " spawnX");
                float posY = PlayerPrefs.GetFloat("Student" + i + " spawnY");

                //time stuff
                int enrollSemester = PlayerPrefs.GetInt("Student" + i + " ES");
                int hwStart = PlayerPrefs.GetInt("Student" + i + " HWS");
                int studyStart = PlayerPrefs.GetInt("Student" + i + " SS");
                int lastUpdate = PlayerPrefs.GetInt("Student" + i + " LU");

                //build enrolled student
                //getEnrolledStudent();
                newStudent = new GameObject("Student" + i);

                //remake sprite
                newHair = Instantiate(hairs[hair]);
                newHair.transform.parent = newStudent.transform;

                newHead = Instantiate(heads[head]);
                newHead.transform.parent = newStudent.transform;

                newClothes = Instantiate(clothes[clothing]);
                newClothes.transform.parent = newStudent.transform;

                newBody = Instantiate(bodies[head]);
                newBody.transform.parent = newStudent.transform;

                //add student data script
                StudentData newData = newStudent.AddComponent<StudentData>();

                //add attributes
                newData.name = name;
                newData.tagline = tagline;
                newData.major = major;
                newData.CGPA = CGPA;

                newStudent.AddComponent<BoxCollider2D>();
                newStudent.GetComponent<BoxCollider2D>().isTrigger = true;
                newStudent.GetComponent<BoxCollider2D>().size = new Vector2(0.25f, 0.25f);
                newStudent.AddComponent<showPopup>();

                newData.lastUpdate = lastUpdate;
                newData.studyStart = studyStart;
                newData.hwStart = hwStart;
                newData.enrollSemester = enrollSemester;

                newStudent.tag = "Student";

                createStudent.students.Add(newStudent);

                if (state == 4)
                {
                    print("grad");
                }
                else if (state < 3)
                {
                    print("pos " + posX + " " + posY);
                    spawnPoint = mainCam.ScreenToWorldPoint(new Vector3(posX, posY, 1));
                    newStudent.transform.Translate(spawnPoint);
                    newStudent.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
