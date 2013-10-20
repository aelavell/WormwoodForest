using UnityEngine;
using System.Collections;

public class BucketHotspot : MonoBehaviour {

	public SimpleAnimation bucket;
	public string hoverIn,hoverOut;

	void OnMouseEnter(){
		if(enabled)
		bucket.PlayAnimByName(hoverIn);
	}

	void OnMouseExit(){
		if(enabled)
		bucket.PlayAnimByName(hoverOut);
	}
	
	void OnMouseDown(){
		if(enabled)
		Static.ArmControl.StartCoroutine(Static.ArmControl.PlayBucket());
	}
}
