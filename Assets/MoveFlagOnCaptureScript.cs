using UnityEngine;
using System.Collections;

public class MoveFlagOnCaptureScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "TeamA")
		{
			WaypointData [] waypointArray = FindObjectsOfType<WaypointData>();
			{
				int randomNumber = Random.Range(0,waypointArray.Length);
				this.gameObject.transform.position = waypointArray[randomNumber].transform.position;
			}
		}
	}
}
