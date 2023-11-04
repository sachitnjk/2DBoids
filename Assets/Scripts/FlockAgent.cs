using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
	Flock agentFlock;
	public Flock AgentFlock { get { return agentFlock; } }

	Collider2D agentCollider;

	//public collider accesor
	public Collider2D AgentCollider {  get {  return agentCollider; } }

	private void Start()
	{
		agentCollider = GetComponent<Collider2D>();
	}

	public void Move(Vector2 velocity)
	{
		//turn agent to direction to move to

		//transform.forward for 3D
		transform.up = velocity;
		transform.position += (Vector3)velocity * Time.deltaTime;
		//actually move the agent to the position to move
	}

	public void Initialize(Flock flock)
	{
		agentFlock = flock;
	}

}
