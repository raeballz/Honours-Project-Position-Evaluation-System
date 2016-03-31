using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject agentPrototype;
	public List <GameObject> activeAgents;


	// Use this for initialization
	void Start () {
		spawnPoint = gameObject.GetComponentInChildren<MeshRenderer>().gameObject;
		agentPrototype.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnNewAgent(float _recalculateDelay, int _searchRadius, int _proximityDesirability, int _loSDistanceToSee, int _loSPenalty){
		GameObject newAgent = Instantiate(agentPrototype, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
		newAgent.SetActive(true);
		newAgent.GetComponent<AICharacterControl>().SetAICharacterControl(_recalculateDelay, _searchRadius, _proximityDesirability, _loSDistanceToSee, _loSPenalty);
		AddAgentToArray(newAgent);
	}

	void AddAgentToArray(GameObject newAgent){
		activeAgents.Add(newAgent);
	}
}
