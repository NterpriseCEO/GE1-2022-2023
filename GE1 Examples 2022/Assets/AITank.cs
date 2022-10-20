using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

	List<Vector3> waypoints = new List<Vector3>();
	public float radius = 10;
	public float speed = 10;
	public int numberOfWaypoints = 5;
	public int currentWaypoint = 0;
	public Transform player;    

	public void OnDrawGizmos() {
		if (!Application.isPlaying) {
			// Task 1
			// Put code here to draw the gizmos
			// Use sin and cos to calculate the positions of the waypoints 
			// You can draw gizmos using

			float angleBetweenWaypoint = (2.0f * Mathf.PI) / numberOfWaypoints;
			for (int i = 0; i < numberOfWaypoints; i++) {
				float theta = i * angleBetweenWaypoint;
				Vector3 position = new Vector3(radius * Mathf.Sin(theta), 0, radius * Mathf.Cos(theta));
				position = transform.TransformPoint(position);
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(position, 1);
			}
		}
	}

	// Use this for initialization
	void Awake () {
		// Task 2
		// Put code here to calculate the waypoints in a loop and 
		// Add them to the waypoints List
		float angleBetweenWaypoint = (2.0f * Mathf.PI) / numberOfWaypoints;
		for (int i = 0; i < numberOfWaypoints; i++) {
			float theta = i * angleBetweenWaypoint;
			Vector3 position = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
			position = transform.TransformPoint(position);
			waypoints.Add(position);
		}
	}

	// Update is called once per frame
	void Update () {
		// Task 3
		// Put code here to move the tank towards the next waypoint
		// When the tank reaches a waypoint you should advance to the next one

		Vector3 distanceToTarget = waypoints[currentWaypoint] - transform.position;
		if (distanceToTarget.magnitude < 1) {
			currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
		}

		distanceToTarget.Normalize();
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distanceToTarget), Time.deltaTime * 5);
		transform.Translate(distanceToTarget * speed * Time.deltaTime, Space.World);

		// Task 4
		// Put code here to check if the player is in front of or behine the tank
		// Task 5
		// Put code here to calculate if the player is inside the field of view and in range
		// You can print stuff to the screen using:
		
		Vector3 distanceToPlayer = player.position - transform.position;
		if (Vector3.Dot(transform.forward, distanceToPlayer) < 0) {
			Debug.Log("The player is behind the AI tank");
		}else {
			Debug.Log("The player is in front of the AI tank");
		}
		float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(transform.forward, distanceToPlayer) / distanceToPlayer.magnitude);
		
		if (angle < 45) {
			Debug.Log("The player is inside the fielf of view of the AI tank");
		} else {
			Debug.Log("The player is outside the field of view of the AI tank");
		}
	}
}
