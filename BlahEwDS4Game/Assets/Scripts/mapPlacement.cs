using UnityEngine;
using System.Collections;

public class mapPlacement : MonoBehaviour {

	double latitude = 45.384333;
	double longitude = -75.698331;
//	float altitude;
//	float horizontal;
	bool temp;

//	double latLow1 = 45.379366;
//	double latHigh1 = 45.388600;
//	double latLow2 = -3.88;
//	double latHigh2 = 5;
//
//	double longLow1 = -75.700600;
//	double longHigh1 = -75.691880;
//	double longLow2 = -2.81;
//	double longHigh2 = 2.81;

	double latLow1 = 45.379000;
	double latHigh1 = 45.388847;
	double latLow2 = -3.88;
	double latHigh2 = 5;
	
	double longLow1 = -75.702949;
	double longHigh1 = -75.689531;
	double longLow2 = -4.44;
	double longHigh2 = 4.44;

	double remapLat;
	double remapLong;

	private Coffee coffeeThings;

	System.DateTime epochStart;
	int systemTime;
	int lastTime;
	int maxCoffeeCollect = 10;
	int coffeeCollected = 0;

	main mainVar;

	// Use this for initialization
	IEnumerator Start () {
		// First, check if user has location service enabled
		mainVar = GameObject.Find ("QUAD").GetComponent<main> ();
		coffeeThings = GetComponent<Coffee> ();

		epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

		if (!Input.location.isEnabledByUser)
			yield break;
		
		// Start service before querying location
		Input.location.Start();
		
		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		
		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			//			print("Timed out");
			yield break;
		}
		
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			//			print("Unable to determine device location");
			temp = false;
			yield break;
		}
		else
		{
			temp = true;
			// Access granted and location value could be retrieved
			//			latitude = Input.location.lastData.latitude;
			//			longtitude = Input.location.lastData.longitude;
			//			altitude = Input.location.lastData.altitude;
			//			horizontal = Input.location.lastData.horizontalAccuracy;
			//			timestamp = Input.location.lastData.timestamp;
			//			print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}
		
		// Stop service if there is no need to query location updates continuously
		//		Input.location.Stop();
	}
	
	// Update is called once per frame
	void Update () {

		systemTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;


		gameObject.GetComponent<SpriteRenderer> ().material.color = Color.black;
//		if (temp) {
//			latitude = Input.location.lastData.latitude;
//			longitude = Input.location.lastData.longitude;
//			altitude = Input.location.lastData.altitude;
//			horizontal = Input.location.lastData.horizontalAccuracy;
			if (latitude > latLow1 && latitude < latHigh1 && longitude > longLow1 && longitude < longHigh1) {
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;
				if(mainVar.scrollDistance != 0){
					longLow2 = -4.44f + mainVar.scrollDistance + 0.04f;
					longHigh2 = 4.44f + mainVar.scrollDistance - 0.04f;
				}				
				remapLat = (latitude - latLow1) / (latHigh1 - latLow1) * (latHigh2 - latLow2) + latLow2;
				remapLong = (longitude - longLow1) / (longHigh1 - longLow1) * (longHigh2 - longLow2) + longLow2;
//				float testNum1 = Mathf.Pow(((float)latitude - 45.384333f),2.0f) + Mathf.Pow (((float)longitude + 75.698331f),2.0f);
//				float testNum2 = Mathf.Pow (0.000072f,2.0f);
//				Debug.Log(testNum1);
//				Debug.Log(testNum2);
			if(locationData((float)latitude, (float)longitude) == 29 && coffeeCollected < maxCoffeeCollect){
//				Debug.Log("Yay");
				if(systemTime - lastTime > 1 && coffeeCollected < maxCoffeeCollect && coffeeThings.coffee < 100){
					coffeeThings.collectCoffee();
					GameObject.Find("coffeeAdd").GetComponent<SpriteRenderer>().enabled = true;
//					Debug.Log(systemTime);
					Debug.Log (coffeeThings.coffee);
					lastTime = systemTime;
					coffeeCollected++;
				}
			}else{
				GameObject.Find("coffeeAdd").GetComponent<SpriteRenderer>().enabled = false;
			}

				//		remapLat = latLow2 + (latitude - latLow2) * (latHigh2 - latLow2) / (latHigh1 - latLow1);
				//		remapLong = longLow2 + (longitude - longLow2) * (longHigh2 - longLow2) / (longHigh1 - longLow1);
//				Debug.Log (remapLat);
//				Debug.Log (remapLong);
			transform.position = new Vector2 ((float)remapLong, (float)remapLat);
			}else{
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.blue;
			}
//		}
	}

	int locationData(float latInput, float longInput){
		float testRadius = Mathf.Pow (0.000072f,2.0f);
		float testAA = Mathf.Pow((latInput - 45.384003f),2.0f) + Mathf.Pow ((longInput + 75.697422f),2.0f);
		float testAP = Mathf.Pow((latInput - 45.382852f),2.0f) + Mathf.Pow ((longInput + 75.699007f),2.0f);
		float testCB = Mathf.Pow((latInput - 45.384141f),2.0f) + Mathf.Pow ((longInput + 75.698514f),2.0f);
		float testTT = Mathf.Pow((latInput - 45.384476f),2.0f) + Mathf.Pow ((longInput + 75.693631f),2.0f);
		float testDT = Mathf.Pow((latInput - 45.382657f),2.0f) + Mathf.Pow ((longInput + 75.699303f),2.0f);
		float testHP = Mathf.Pow((latInput - 45.382179f),2.0f) + Mathf.Pow ((longInput + 75.697418f),2.0f);
		float testNB = Mathf.Pow((latInput - 45.383955f),2.0f) + Mathf.Pow ((longInput + 75.693298f),2.0f);
		float testLA = Mathf.Pow((latInput - 45.380953f),2.0f) + Mathf.Pow ((longInput + 75.699167f),2.0f);
		float testME = Mathf.Pow((latInput - 45.384674f),2.0f) + Mathf.Pow ((longInput + 75.697778f),2.0f);
		float testMC = Mathf.Pow((latInput - 45.385175f),2.0f) + Mathf.Pow ((longInput + 75.696985f),2.0f);
		float testPA = Mathf.Pow((latInput - 45.381903f),2.0f) + Mathf.Pow ((longInput + 75.698575f),2.0f);
		float testCO = Mathf.Pow((latInput - 45.387136f),2.0f) + Mathf.Pow ((longInput + 75.697313f),2.0f);
		float testRB = Mathf.Pow((latInput - 45.382402f),2.0f) + Mathf.Pow ((longInput + 75.696295f),2.0f);
		float testSP = Mathf.Pow((latInput - 45.387478f),2.0f) + Mathf.Pow ((longInput + 75.698328f),2.0f);
		float testSC = Mathf.Pow((latInput - 45.382791f),2.0f) + Mathf.Pow ((longInput + 75.696921f),2.0f);
		float testVS = Mathf.Pow((latInput - 45.380539f),2.0f) + Mathf.Pow ((longInput + 75.700232f),2.0f);
		float testAT = Mathf.Pow((latInput - 45.383174f),2.0f) + Mathf.Pow ((longInput + 75.698677f),2.0f);
		float testSA = Mathf.Pow((latInput - 45.381257f),2.0f) + Mathf.Pow ((longInput + 75.699636f),2.0f);
		float testTB = Mathf.Pow((latInput - 45.382663f),2.0f) + Mathf.Pow ((longInput + 75.698146f),2.0f);
		float testUC = Mathf.Pow((latInput - 45.383408f),2.0f) + Mathf.Pow ((longInput + 75.697819f),2.0f);
		float testBAKERS = Mathf.Pow((latInput - 45.383581f),2.0f) + Mathf.Pow ((longInput + 75.698139f),2.0f);
		float testBENTCOIN = Mathf.Pow((latInput - 45.383336f),2.0f) + Mathf.Pow ((longInput + 75.694311f),2.0f);
		float testFOODCOURT = Mathf.Pow((latInput - 45.383334f),2.0f) + Mathf.Pow ((longInput + 75.697499f),2.0f);
		float testFRESHFOOD = Mathf.Pow((latInput - 45.387154f),2.0f) + Mathf.Pow ((longInput + 75.697292f),2.0f);
		float testLOEBCAFE = Mathf.Pow((latInput - 45.380953f),2.0f) + Mathf.Pow ((longInput + 75.698992f),2.0f);
		float testOASIS = Mathf.Pow((latInput - 45.387027f),2.0f) + Mathf.Pow ((longInput + 75.697087f),2.0f);
		float testPAGEBREAK = Mathf.Pow((latInput - 45.382271f),2.0f) + Mathf.Pow ((longInput + 75.699539f),2.0f);
		float testTUNNELJUNCTION = Mathf.Pow((latInput - 45.381819f),2.0f) + Mathf.Pow ((longInput + 75.699031f),2.0f);
		float testSECONDCUP = Mathf.Pow((latInput - 45.384333f),2.0f) + Mathf.Pow ((longInput + 75.698331f),2.0f);
		float testSTARBUCKS = Mathf.Pow((latInput - 45.383234f),2.0f) + Mathf.Pow ((longInput + 75.698081f),2.0f);
		float testROOSTERS = Mathf.Pow((latInput - 45.383153f),2.0f) + Mathf.Pow ((longInput + 75.698022f),2.0f);
		float testTIMAC = Mathf.Pow((latInput - 48.386274f),2.0f) + Mathf.Pow ((longInput + 75.693768f),2.0f);
		float testTIMCO = Mathf.Pow((latInput - 45.38718f),2.0f) + Mathf.Pow ((longInput + 75.697223f),2.0f);
		float testTIMUC1 = Mathf.Pow((latInput - 45.383462f),2.0f) + Mathf.Pow ((longInput + 75.697741f),2.0f);
		float testTIMUC4 = Mathf.Pow((latInput - 45.383307f),2.0f) + Mathf.Pow ((longInput + 75.69802f),2.0f);
		float testTIMRB = Mathf.Pow((latInput - 45.382156f),2.0f) + Mathf.Pow ((longInput + 75.696224f),2.0f);

		if (testAA < testRadius) {
			return 1;
		} else if (testAP < testRadius) {
			return 2;
		} else if (testCB < testRadius) {
			return 3;
		} else if (testTT < testRadius) {
			return 4;
		} else if (testDT < testRadius) {
			return 5;
		} else if (testHP < testRadius) {
			return 6;
		} else if (testNB < testRadius) {
			return 7;
		} else if (testLA < testRadius) {
			return 8;
		} else if (testME < testRadius) {
			return 9;
		} else if (testMC < testRadius) {
			return 10;
		} else if (testPA < testRadius) {
			return 11;
		} else if (testCO < testRadius) {
			return 12;
		} else if (testRB < testRadius) {
			return 13;
		} else if (testSP < testRadius) {
			return 14;
		} else if (testSC < testRadius) {
			return 15;
		} else if (testVS < testRadius) {
			return 16;
		} else if (testAT < testRadius) {
			return 17;
		} else if (testSA < testRadius) {
			return 18;
		} else if (testTB < testRadius) {
			return 19;
		} else if (testUC < testRadius) {
			return 20;
		} else if (testBAKERS < testRadius) {
			return 21;
		} else if (testBENTCOIN < testRadius) {
			return 22;
		} else if (testFOODCOURT < testRadius) {
			return 23;
		} else if (testFRESHFOOD < testRadius) {
			return 24;
		} else if (testLOEBCAFE < testRadius) {
			return 25;
		} else if (testOASIS < testRadius) {
			return 26;
		} else if (testPAGEBREAK < testRadius) {
			return 27;
		} else if (testTUNNELJUNCTION < testRadius) {
			return 28;
		} else if (testSECONDCUP < testRadius) {
			return 29;
		} else if (testSTARBUCKS < testRadius) {
			return 30;
		} else if (testROOSTERS < testRadius) {
			return 31;
		} else if (testTIMAC < testRadius) {
			return 32;
		} else if (testTIMCO < testRadius) {
			return 33;
		} else if (testTIMUC1 < testRadius) {
			return 34;
		} else if (testTIMUC4 < testRadius) {
			return 35;
		} else if (testTIMRB < testRadius) {
			return 36;
		} else {
			return 0;
		}
	}

	//Buildings
//	bool AA(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.384003f),2.0f) + Mathf.Pow ((longInput + 75.697422f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool AP(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382852f),2.0f) + Mathf.Pow ((longInput + 75.699007f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool CB(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.384141f),2.0f) + Mathf.Pow ((longInput + 75.698514f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool TT(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.384476f),2.0f) + Mathf.Pow ((longInput + 75.693631f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool DT(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382657f),2.0f) + Mathf.Pow ((longInput + 75.699303f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool HP(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382179f),2.0f) + Mathf.Pow ((longInput + 75.697418f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool NB(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383955f),2.0f) + Mathf.Pow ((longInput + 75.693298f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool LA(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.380953f),2.0f) + Mathf.Pow ((longInput + -75.699167f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool ME(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.384674f),2.0f) + Mathf.Pow ((longInput + 75.697778f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool MC(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.385175f),2.0f) + Mathf.Pow ((longInput + 75.696985f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool PA(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.381903f),2.0f) + Mathf.Pow ((longInput + 75.698575f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool CO(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.387136f),2.0f) + Mathf.Pow ((longInput + 75.697313f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool RB(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382402f),2.0f) + Mathf.Pow ((longInput + 75.696295f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool SP(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.387478f),2.0f) + Mathf.Pow ((longInput + 75.698328f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
//	bool SC(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382791f),2.0f) + Mathf.Pow ((longInput + 75.696921f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
//	bool VS(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.380539f),2.0f) + Mathf.Pow ((longInput + 75.700232f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool AT(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383174f),2.0f) + Mathf.Pow ((longInput + 75.698677f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool SA(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.381257f),2.0f) + Mathf.Pow ((longInput + 75.699636f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool TB(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382663f),2.0f) + Mathf.Pow ((longInput + 75.698146f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool UC(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383408f),2.0f) + Mathf.Pow ((longInput + 75.697819f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

	//Coffee Locations
//	bool bakers(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383581f),2.0f) + Mathf.Pow ((longInput + 75.698139f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool bentCoin(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383336f),2.0f) + Mathf.Pow ((longInput + 75.694311f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool foodCourt(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383334f),2.0f) + Mathf.Pow ((longInput + 75.697499f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool freshFood(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.387154f),2.0f) + Mathf.Pow ((longInput + 75.697292f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool loebCafe(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.380953f),2.0f) + Mathf.Pow ((longInput + 75.698992f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool oasis(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.387027f),2.0f) + Mathf.Pow ((longInput + 75.697087f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool pageBreakStarbucks(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382271f),2.0f) + Mathf.Pow ((longInput + 75.699539f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool tunnelJunction(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.381819f),2.0f) + Mathf.Pow ((longInput + 75.699031f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool secondCup(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.384333f),2.0f) + Mathf.Pow ((longInput + 75.698331f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
	
//	bool starbucks(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383234f),2.0f) + Mathf.Pow ((longInput + 75.698081f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
	
//	bool roosters(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383153f),2.0f) + Mathf.Pow ((longInput + 75.698022f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
	
//	bool timAC(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 48.386274f),2.0f) + Mathf.Pow ((longInput + 75.693768f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
	
//	bool timCO(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.38718f),2.0f) + Mathf.Pow ((longInput + 75.697223f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool timUC1(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383462f),2.0f) + Mathf.Pow ((longInput + 75.697741f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool timUC4(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.383307f),2.0f) + Mathf.Pow ((longInput + 75.69802f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}

//	bool timRB(float latInput, float longInput){
//		float testNum1 = Mathf.Pow((latInput - 45.382156f),2.0f) + Mathf.Pow ((longInput + 75.696224f),2.0f);
//		float testNum2 = Mathf.Pow (0.000072f,2.0f);
//		if (testNum1 < testNum2) {
//			return true;
//		} else {
//			return false;
//		}
//	}
}