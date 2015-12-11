using UnityEngine;
using System.Collections;

public class CollectStudent : MonoBehaviour {

    private GameObject studentGen;
    private CreateStudent createStudent;

    // Use this for initialization
    void Start()
    {
        studentGen = GameObject.Find("GameObject");
        createStudent = studentGen.GetComponent<CreateStudent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        createStudent.keepStudent(this.transform.parent.gameObject);
    }
}
