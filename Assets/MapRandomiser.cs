using UnityEngine;
using System.Collections;

public class MapRandomiser : MonoBehaviour {
	private GameObject [] obstacleArray;
	private float rand;

	// Use this for initialization
	void Start () {
		obstacleArray = GameObject.FindGameObjectsWithTag("Obstacles");
		Randomise();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Randomise(){
		foreach(GameObject obstacle  in obstacleArray){
			rand = Random.value;
			rand = Mathf.Round(rand);
			if (rand == 0){
				obstacle.SetActive(false);
			} else { obstacle.SetActive(true);};
		}
	}
}
