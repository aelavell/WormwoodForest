using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	float smooth = 15;
	Vector3 targetPosition;
	
	void Update () {
		var playerPlane = new Plane(Vector3.forward, transform.position);
		
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hitdist = 0.0f;
 
		if (playerPlane.Raycast(ray, out hitdist)) {
			var targetPoint = ray.GetPoint(hitdist);
			targetPosition = new Vector3(targetPoint.x, targetPoint.y, 0);
		}
		
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
	}
}
