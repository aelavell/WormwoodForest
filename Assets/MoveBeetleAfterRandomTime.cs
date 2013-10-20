using UnityEngine;
using System.Collections;

public class MoveBeetleAfterRandomTime : MonoBehaviour {
	public Renderer beetleRenderer;
	public ArmHotspot hotspot;
	float timeLeft;
	// Update is called once per frame
	void Update () {
		if(timeLeft <= 0){
			beetleRenderer.enabled = true;
			hotspot.enabled = true;
			GetComponent<SimpleAnimation>().PlayAnimByName("MoveBeetle", true);
			timeLeft = Random.Range (11, 13);
		}
		timeLeft -= Time.deltaTime;
	}

	public void Plucked(){
		beetleRenderer.enabled = false;
		hotspot.enabled = false;
	}
}
