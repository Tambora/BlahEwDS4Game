using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class grads : MonoBehaviour {
	
	
	GameObject newGravatar;
	GameObject gradList;
	GameObject entireList;
	List<GameObject> grAvatars = new List<GameObject>();
	
	private int gradCount = 0;
	private int oldGradCount = 0; 
	public int pageNumbers = 4; 		// THIS NEEDS TO BE CHANGED DEPENDING ON THE PAGE NUMBER... !
	public int stars = 0;				// THIS WILL BE >0 IF THERE ARE NEW GRADS

	
	CreateStudent cs;
	GetSavedStudent gss;
	// Use this for initialization
	void Start()
	{		
		GameObject g = GameObject.Find("GameObject");
		cs = g.GetComponent<CreateStudent>();
		gss = g.GetComponent<GetSavedStudent> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnMouseDown(){
		if (!GameObject.Find ("gradList(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gratzPop(Clone)") && !GameObject.Find ("SettingsMenu(Clone)") ) {
			gradList = Instantiate (Resources.Load ("gradList")) as GameObject;
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
			List<GameObject> gradBox = new List<GameObject>();


			oldGradCount = gss.gradCount; 
			gradCount = 0;
			int count = 0;
			int studentCount = 0;
			int pages;
			int np = 4;
			int thisPage = 0;

			for(int i=0; PlayerPrefs.HasKey("Student"+i+" studentState"); i++) {
				if (PlayerPrefs.GetInt("Student"+i+" studentState") == 4) {
					gradCount++;
				}
				studentCount = i;
			}
			print(pageNumbers);
			if (gradCount > oldGradCount){
				stars = gradCount - oldGradCount;
				oldGradCount = gradCount;
			}

			if (pageNumbers > gradCount/4){
				pageNumbers = gradCount/4;
				print(pageNumbers);
			}
			else if (pageNumbers >= gradCount/4 && gradCount%4 > 0){
				pageNumbers = (gradCount - gradCount%4)/4 + 1;
				print(pageNumbers);
			}
			else if (pageNumbers < 1){
				pageNumbers = 1;
				print(pageNumbers);
			}

			thisPage = gradCount;


			for (int i = studentCount; i > 0; i--){
				if (PlayerPrefs.GetInt("Student"+i+" studentState") == 4){
					if((gradCount - (pageNumbers-1)*4) >= thisPage && np > 0){
						print(pageNumbers);
					
						gradBox.Add(Instantiate (Resources.Load ("UI_GradBox"))as GameObject);
						gradBox[count].GetComponentsInChildren<TextMesh>()[0].text = PlayerPrefs.GetString("Student"+i+" name");
						
						newGravatar = new GameObject("Gravatar"+count);

						GameObject hair = Instantiate(cs.hairs[PlayerPrefs.GetInt("Student"+i+" hair")]);
						GameObject head = Instantiate(cs.heads[PlayerPrefs.GetInt("Student"+i+" head")]);
						GameObject body = Instantiate(cs.bodies[PlayerPrefs.GetInt("Student"+i+" head")]);
						GameObject clothes = Instantiate(cs.clothes[PlayerPrefs.GetInt("Student"+i+" clothes")]);
						
						hair.GetComponent<Renderer>().sortingLayerName = "Foreground";
						hair.GetComponent<Renderer>().sortingOrder = 2;
						head.GetComponent<Renderer>().sortingLayerName = "Foreground";
						head.GetComponent<Renderer>().sortingOrder = 1;
						clothes.GetComponent<Renderer>().sortingLayerName = "Foreground";
						clothes.GetComponent<Renderer>().sortingOrder = 1;
						body.GetComponent<Renderer>().sortingLayerName = "Foreground";
						
						hair.transform.parent = newGravatar.transform;
						head.transform.parent = newGravatar.transform;
						clothes.transform.parent = newGravatar.transform;
						body.transform.parent = newGravatar.transform;
						
						newGravatar.transform.Translate(-1.3f, 0, 0);
						newGravatar.transform.localScale += new Vector3(1.5f,1.5f,1.5f);
						newGravatar.transform.parent = gradBox[count].transform;
						grAvatars.Add(newGravatar);
						
						gradBox[count].transform.Translate(0,3.4f-(count)*1.7f,0);
						gradBox[count].transform.parent = gradList.transform;
						count++;
						np--;
					}
					thisPage--;
				}
			}
		}
	}
}







