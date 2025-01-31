using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PatrollingEnemy : MonoBehaviour {

	private Vector3 startPosition;  //Give it a startPosition so it knows where it's 'home' location is.
	private bool wandering = true;  //Set a bool or state so it knows if it's wandering or chasing a player
	private bool chasing = false;
	[SerializeField] private float wanderSpeed;  //Give it the movement speeds
	private GameObject target;  //The target you want it to chase
    [SerializeField] private float MINwanderRange;
    [SerializeField] private float MAXwanderRange;
    private NavMeshAgent agent;
    [SerializeField] float DswitchCounter;
    
   


	//When the enemy is spawned via script or if it's pre-placed in the world we want it to first
	//Get it's location and store it so it knows where it's 'home' is
	//We also want ti set it's speed and then start wandering
	void Awake(){
		//Get the NavMeshAgent so we can send it directions and set start position to the initial location
		agent = GetComponent("NavMeshAgent") as UnityEngine.AI.NavMeshAgent;
		agent.speed = wanderSpeed;  
		startPosition = this.transform.position;
		//Start Wandering
		InvokeRepeating("Wander", 1f, 5f);
	}

	//When we wander we essentially want to pick a random point and then send the agent there
	//Random.Range is perfect for this.
	//If you're working on a hilly terrain you may want to change your y to a higher point and then
	//Use a raycast down to hit the 'terrain' point, rather than keeping y at 0.
	//y at 0 would only work if you have a completely flat floor.
	void Wander(){
		//Pick a random location within wander-range of the start position and send the agent there
		Vector3 destination = startPosition + new Vector3(Random.Range (MINwanderRange, MAXwanderRange), 
		                                                  0, 
		                                                  Random.Range (MINwanderRange, MAXwanderRange));
		NewDestination(destination);
	}


	//Creating this as it's own method so we can send it directions other when it's just wandering.
	public void NewDestination(Vector3 targetPoint){
		//Sets the agents new target destination to the position passed in
		agent.SetDestination (targetPoint);
	}
    void Update() 
    {
       
      
        Debug.Log(DswitchCounter);
    }
}