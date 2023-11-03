using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (menuName = "Flock/Behaviour/Steered Cohesion")]
public class SteeredCohesionBehaviour : FlockBehaviour
{
	Vector2 currentVelocity;
	public float agentSmoothTime = 0.5f;

	public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
	{
		//if no neighbours, return no adjustment
		if (context.Count == 0)
		{
			return Vector2.zero;
		}

		//add all points together and average
		Vector2 cohesionMove = Vector2.zero;
		foreach (Transform item in context)
		{
			cohesionMove += (Vector2)item.position;
		}
		cohesionMove /= context.Count;

		//create offset from agent position
		cohesionMove -= (Vector2)agent.transform.position;
		//using smoothDamp to remove the flickering of agents
		cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);

		//finds middle point between all neighbours and tries to move there
		return cohesionMove;
	}
}
