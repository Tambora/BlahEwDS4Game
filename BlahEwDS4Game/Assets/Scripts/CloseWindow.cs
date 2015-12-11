using UnityEngine;
using System.Collections;

public class CloseWindow : MonoBehaviour {

    private GameObject studentGen;
    private CreateStudent createStudent;

    bool first = true;

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
        if ( createStudent.first )
        {
            createStudent.SpawnStudent();
            createStudent.first = false;
        }

        Destroy(this.transform.parent.gameObject);
    }
}
