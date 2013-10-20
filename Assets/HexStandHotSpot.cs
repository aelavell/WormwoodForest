using UnityEngine;
using System.Collections;

public class HexStandHotSpot : MonoBehaviour {

	public string hoverIn,hoverOut;
	private bool lastFrame = false;
	public Rect screenRect;

	void Update(){
		Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
		if(screenRect.Contains(Camera.main.ScreenToViewportPoint(Input.mousePosition))){
			if(!lastFrame)
				OnEnter();
			lastFrame = true;
		}
		else{
			if(lastFrame)
				OnExit ();
			lastFrame = false;
		}
	}

	void OnEnter(){
		if(enabled){
			Static.ArmControl.SetHand(HandType.Poking);
			Static.ArmControl.GetComponent<SimpleAnimation>().PlayAnimByName(hoverIn);
		}
	}

	void OnExit(){
		if(enabled){
			Static.ArmControl.GetComponent<SimpleAnimation>().PlayAnimByName(hoverOut);
		}
	}

}
