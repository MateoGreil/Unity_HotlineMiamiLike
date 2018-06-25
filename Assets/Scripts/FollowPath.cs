using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

	#region Enums
	public enum MovementType //Type of movement
	{
		MoveTowards,
		LerpTowards
	}
	#endregion

	#region Public Variables
	public MovementType Type = MovementType.MoveTowards;
	public MovementPath MyPath;
	public float speed = 1;
	public float MaxDistanceToGoal = .1f; //How close does it have to be to the point to e considered at point
	public bool	isRotating = false;
	#endregion
	
	#region Private Variables
	private IEnumerator<Transform> pointInPath;
	#endregion

	// Use this for initialization
	void Start () {
		if (MyPath == null) {
			Debug.LogError("MovementPath cannot be null", gameObject);
			return;
		}
		//Sets up a reference to  an instance of the coroutine GetNextPathPoint
		pointInPath = MyPath.GetNextPathPoint();
		//Get the next point in the path to move to
		pointInPath.MoveNext();
		if (pointInPath.Current == null) {
			Debug.LogError("A path must have points to follow", gameObject);
			return;
		}
		//Set the position of the object to the position of the starting point
		transform.position = pointInPath.Current.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pointInPath == null || pointInPath.Current == null)
			return;
		if (Type == MovementType.MoveTowards)
		{
			//Move to the next point
			transform.position = Vector3.MoveTowards(transform.position,
				pointInPath.Current.position, Time.deltaTime * speed);
			if (isRotating) {
				//Look towards the next point
				Vector3 vectorToTarget = pointInPath.Current.position - transform.position;
				float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
			}
		}
		else if (Type == MovementType.LerpTowards)
		{
			//Move to the next point using lerp
			transform.position = Vector3.Lerp(transform.position,
				pointInPath.Current.position, Time.deltaTime * speed);
		}
		//Check to see if close enough to the next point using Pythagore
		var distanceSquared =(transform.position - pointInPath.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			pointInPath.MoveNext();
	}
}
