using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
	public FlockAgent agentPrefab;
	List<FlockAgent> agents = new List<FlockAgent>();
	public FlockBehaviour behaviour;

	[Range(10, 500)]
	public int startingCount = 250;
	const float AgentDensity = 0.08f;

	[Range(1f, 100f)]
	public float driveFactor = 10f;
	[Range(1f, 100f)]
	public float maxSpeed = 5f;

	[Range(1f, 10f)]
	public float neighborRadius = 1.5f;
	[Range(0f, 1f)]
	public float avoidancerandiusMultiplier = 0.5f;

	//calculating squares and comparing squares instead of using roots everytime, saving some math calculation
	float squareMaxSpeed;
	float squareNeighborRadius;
	float squareAvoidanceRadius;
	public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

	private void Start()
	{
		squareMaxSpeed = maxSpeed * maxSpeed;
		squareNeighborRadius = neighborRadius * neighborRadius;
		squareAvoidanceRadius = squareNeighborRadius * avoidancerandiusMultiplier * avoidancerandiusMultiplier;

		for ( int i = 0; i < startingCount; i++ ) 
		{
			FlockAgent newAgent = Instantiate(
				agentPrefab, 
				Random.insideUnitCircle * startingCount * AgentDensity,
				Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
				transform
				);
			newAgent.name = "Agent " + i;
			agents.Add( newAgent );
		}
	}

}
