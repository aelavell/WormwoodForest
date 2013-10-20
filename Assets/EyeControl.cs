using UnityEngine;
using System.Collections;

public class EyeControl : MonoBehaviour {

	public Renderer open, empty, closing, blink;
	public ArmHotspot hotspot;
	bool plucked;

	void Update(){
		if(!plucked){
			if(Mathf.Repeat(Time.time, 3.8f) > 3.5f){
				open.enabled = false;
				blink.enabled = true;
			}
			else{
				open.enabled = true;
				blink.enabled = false;
			}
		}
	}

	public IEnumerator Plucked(){
		hotspot.enabled = false;
		plucked = true;
		foreach(Transform child in transform){
			child.renderer.enabled = false;
		}
		empty.enabled = true;
		yield return new WaitForSeconds(5);
		empty.enabled = false;
		closing.enabled = true;
		yield return new WaitForSeconds(0.5f);
		closing.enabled = false;
		yield return new WaitForSeconds(1f);
		open.enabled = true;
		plucked = false;
		hotspot.enabled = true;
	}
}
