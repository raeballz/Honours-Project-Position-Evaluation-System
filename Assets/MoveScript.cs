// MoveDestination.cs
	using UnityEngine;

public class MoveScript : MonoBehaviour {
	
	public Transform goal;
	public Transform target;
	Vector3 destination;
	NavMeshAgent agent;

	
	void start () {

	}

	void update(){
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}
}