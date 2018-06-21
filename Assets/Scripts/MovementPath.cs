using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour {

	#region Enums
	public enum PathTypes
	{
		linear,
		loop
	}
	#endregion

	#region Public Variables
	public PathTypes PathType;
	public int movementDirection = 1; //1 = Clockwise, *1 = counter clockwise
	public int movingTo = 0; //Used to determine which point to go to
	public Transform[] PathSequence; //Array of the points to go through in the path
	#endregion

	public void OnDrawGizmos() {
		//Verify if path has at leat two points
		if (PathSequence == null || PathSequence.Length < 2)
			return;
		//Draw lines between points
		for (int i = 1; i < PathSequence.Length; i++)
			Gizmos.DrawLine(PathSequence[i-1].position, PathSequence[i].position);
		//Draw line from last point to first if is a loop
		if (PathType == PathTypes.loop)
			Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length-1].position);
	}

	public IEnumerator<Transform> GetNextPathPoint() {
		if (PathSequence == null || PathSequence.Length < 1)
			yield break;

		while (true) //Does not infinite loop thanks to yeild return
		{
			//Returns current point in pathSequence and wait for next call of enumerator
			yield return PathSequence[movingTo];

			//Exit coroutine if only one point
			if (PathSequence.Length == 1)
				continue;
			//If linear, go to the final point and go the other way
			if (PathType ==PathTypes.linear)
			{
				if (movingTo <= 0)
					movementDirection = 1;
				else if (movingTo >= PathSequence.Length - 1)
					movementDirection = -1;
			}
			movingTo = movingTo + movementDirection;
			//If loop, always 
			if (PathType == PathTypes.loop)
			{
				if (movingTo >= PathSequence.Length)
					movingTo = 0;
				//If moving backwards
				else if (movingTo < 0)
					movingTo = PathSequence.Length - 1;
			}
		}
	}
}
