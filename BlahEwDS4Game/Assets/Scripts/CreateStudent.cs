using UnityEngine;
using System.Collections;

public class CreateStudent : MonoBehaviour {

    private GameObject newStudent;
    private GameObject[] students;

    public GameObject[] bodies;
    public GameObject[] clothes;
    public GameObject[] hairs;

    private GameObject newBody;
    private GameObject newClothes;
    private GameObject newHair;

    private int rand;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnMouseDown()
    {
        newStudent = new GameObject("Student");

        rand = Random.Range(0, bodies.Length);
        newBody = Instantiate(bodies[rand]);
        newBody.transform.parent = newStudent.transform;

        rand = Random.Range(0, clothes.Length);
        newClothes = Instantiate(clothes[rand]);
        newClothes.transform.parent = newStudent.transform;

        rand = Random.Range(0, hairs.Length);
        newHair = Instantiate(hairs[rand]);
        newHair.transform.parent = newStudent.transform;

    }
}
