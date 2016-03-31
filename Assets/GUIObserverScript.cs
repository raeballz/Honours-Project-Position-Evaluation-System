using UnityEngine;
using System.Collections;

public class GUIObserverScript : MonoBehaviour {
	//public float hSliderValue = 0.0f;

	public float hSlider_slowMoValue;
	public float hSlider_RecalculateDelay;
	public int hSlider_LoSDistanceToSee;
	public int hSlider_LoSPenalty;
	public int hSlider_SearchRadius;
	public int hSlider_ProximityDesirability;

	public GameObject AIAgent;

	public MapRandomiser mapRand;

	public GameObject startPoint;
	private Vector3 startPointPos;
	private Quaternion startPointRot;

	GameController gameController;

	//private GameObject cloneAgent;

	void Start(){
		mapRand = GameObject.FindGameObjectWithTag("ObstacleController").GetComponent<MapRandomiser>();
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		startPointPos = gameController.spawnPoint.transform.position;
		startPointRot = gameController.spawnPoint.transform.rotation;
		//cloneAgent = gameController.agentPrototype;
		//cloneAgent = Instantiate(AIAgent,startPointPos,startPointRot) as GameObject;
		//cloneAgent.SetActive(false);
	}

	void Update(){
		Time.timeScale = hSlider_slowMoValue;
	}

	void OnGUI(){
		GUI.Label(new Rect(25, 10, 160, 20), "Timescale");
		hSlider_slowMoValue = GUI.HorizontalSlider(new Rect(25,30,100,20), hSlider_slowMoValue, 0f, 1f);
		GUI.Label(new Rect(130, 25, 50, 20), hSlider_slowMoValue.ToString());

		GUI.Label(new Rect(25, 50, 160, 20), "Reaction Time (seconds)");
		hSlider_RecalculateDelay = GUI.HorizontalSlider(new Rect(25,70,100,20), hSlider_RecalculateDelay, 0f, 5f);
		GUI.Label(new Rect(130, 65, 50, 20), hSlider_RecalculateDelay.ToString());

		GUI.Label(new Rect(25, 90, 160, 20), "Distance To See (meters)");
		hSlider_LoSDistanceToSee= Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(25,110,100,20), hSlider_LoSDistanceToSee , 1, 50));
		GUI.Label(new Rect(130, 105, 50, 20), hSlider_LoSDistanceToSee.ToString());

		GUI.Label(new Rect(25, 130, 160, 20), "Line of Sight Penalty");
		hSlider_LoSPenalty = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(25,150,100,20), hSlider_LoSPenalty , 0, 150));
		GUI.Label(new Rect(130, 145, 50, 20), hSlider_LoSPenalty.ToString());

		GUI.Label(new Rect(25, 170, 160, 20), "Search Radius (meters)");
		hSlider_SearchRadius= Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(25, 190,100,20), hSlider_SearchRadius, 0, 30));
		GUI.Label(new Rect(130, 185, 50, 20), hSlider_SearchRadius.ToString());

		GUI.Label(new Rect(25, 210, 160, 20), "Proximity Desirability");
		hSlider_ProximityDesirability = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(25,230,100,20), hSlider_ProximityDesirability, 0, 100));
		GUI.Label(new Rect(130, 225, 50, 20), hSlider_ProximityDesirability.ToString());

		if(GUI.Button(new Rect(25, 250, 45, 45), "Rand.")){
			mapRand.Randomise();
		}

		if(GUI.Button(new Rect(80, 250, 45, 45), "Del.")){
			foreach (GameObject agent in gameController.activeAgents) {
				gameController.activeAgents.Remove(agent);
				Destroy(agent);
			}
		}

		if(GUI.Button(new Rect(25, 300, 100, 45), "New Agent")){
			gameController.SpawnNewAgent(hSlider_RecalculateDelay,hSlider_SearchRadius,hSlider_ProximityDesirability,hSlider_LoSDistanceToSee,hSlider_LoSPenalty);
		}


	}
}
