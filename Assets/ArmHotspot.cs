using UnityEngine;
using System.Collections;

public class ArmHotspot : MonoBehaviour {
	public string animationName;

	void OnMouseHover(){

	}
	
	void OnMouseDown(){
		Static.ArmControl.GetComponent<SimpleAnimation>().PlayAnimByName(animationName);
	}
}
