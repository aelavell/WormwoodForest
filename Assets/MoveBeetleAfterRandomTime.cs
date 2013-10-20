using UnityEngine;
using System.Collections;

public class MoveBeetleAfterRandomTime : MonoBehaviour {
	float timeLeft;
	// Update is called once per frame
	void Update () {
		if(timeLeft <= 0){
			GetComponent<SimpleAnimation>().PlayAnimByName("MoveBeetle");
			timeLeft = Random.Range (12, 20);
		}
	}
}
