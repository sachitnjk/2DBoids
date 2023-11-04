using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContextFilter : ScriptableObject
{
	//agent - to compare against other agent in the list, original - original list of transforms of neighbors
	public abstract List<Transform> Filter(FlockAgent agent, List<Transform> original);
}
