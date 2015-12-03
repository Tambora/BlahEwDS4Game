using UnityEngine;
using System.Collections;

public class Names : MonoBehaviour {

    //I didn't know what to put for names so I started just putting in game of thrones characters
    //Maybe for the final we can pull from a database or something?

    private string[] firstNames = new string[] 
    {
        "Abbacus",
        "Star",
        "Dudley",
        "Baxter",
        "Apple",
        "Beavis",
        "Papyrus",
        "Samuel",
        "Vladimir",
        "Mara",
        "Gordon",
        "Isabela",
        "Lesley",
        "Stan",
        "Pearl",
        "Elspeth",
        "Danaerys",
        "John",
        "Cersei",
        "Nedd",
        "Tyrion",
        "Sansa",
        "Aria",
        "Vyserys",
        "Jorah",
        "Jaime",
        "Samwell",
        "Theon",
        "Petyr",
        "Varys",
        "Brienne",
        "Tywin",
        "Joffrey",
        "Margaery",
        "Tommen",
        "Roose",
    };

    private string[] lastNames = new string[] 
    {
        "Sandwhich",
        "Mito",
        "Freeman",
        "Baggins",
        "Fish",
        "Chopp",
        "Butterfly",
        "Pines",
        "Humblebloom",
        "Squarepants",
        "Stark",
        "Targaryen",
        "Greyjoy",
        "Lannister",
        "Tyrell",
        "Snow",
        "Baratheon",
        "Mormont",
        "Arryn",
        "Tarth",
        "Clegane",
        "Hornwood",
        "Cerwyn",
        "Manderly",
        "Florent",
        "Baelish",
        "Whent",
        "Marbrand",
        "Rewyne",
        "Dayne",
        "Glover",
        "Karstark",
        "Bolton",
        "Estermont",
        "Dondarrion",
        "Connington",
    };

    private string fNamePick;
    private string lNamePick;
    private string fullName;

    public string getName()
    {
        fNamePick = firstNames[Random.Range(0, firstNames.Length)];
        lNamePick = lastNames[Random.Range(0, lastNames.Length)];

        fullName = fNamePick + " " + lNamePick;
        
        return fullName;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
