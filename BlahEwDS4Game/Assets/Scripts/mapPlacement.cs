using UnityEngine;
using System.Collections;

public class mapPlacement : MonoBehaviour {

	double latitude = 45.382852;
	double longitude = -75.699007;
//	float altitude;
//	float horizontal;
	bool temp;

	double latLow1 = 45.379126;
	double latHigh1 = 45.388847;
	double latLow2 = -2.87;
	double latHigh2 = 2.87;

	double longLow1 = -75.702949;
	double longHigh1 = -75.689531;
	double longLow2 = -2.87;
	double longHigh2 = 2.87;

	double remapLat;
	double remapLong;

	// Use this for initialization
	IEnumerator Start () {
		// First, check if user has location service enabled

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
		gameObject.GetComponent<SpriteRenderer> ().material.color = Color.black;
		if (temp) {
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
//			altitude = Input.location.lastData.altitude;
//			horizontal = Input.location.lastData.horizontalAccuracy;
			if (latitude > latLow1 && latitude < latHigh1 && longitude > longLow1 && longitude < longHigh1) {
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;
				remapLat = (latitude - latLow1) / (latHigh1 - latLow1) * (latHigh2 - latLow2) + latLow2;
				remapLong = (longitude - longLow1) / (longHigh1 - longLow1) * (longHigh2 - longLow2) + longLow2;
				//		remapLat = latLow2 + (latitude - latLow2) * (latHigh2 - latLow2) / (latHigh1 - latLow1);
				//		remapLong = longLow2 + (longitude - longLow2) * (longHigh2 - longLow2) / (longHigh1 - longLow1);
//				Debug.Log (remapLat);
//				Debug.Log (remapLong);
				transform.position = new Vector2 ((float)remapLong, (float)remapLat);
			}else{
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.blue;
			}
		}
	}
}
