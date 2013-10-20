using UnityEngine;
using System.Collections;

public class BucketHotspot : MonoBehaviour {

	public SimpleAnimation bucket;
	public string hoverIn,hoverOut;

	void OnMouseEnter(){
		bucket.PlayAnimByName(hoverIn);
	}

	void OnMouseExit(){
		bucket.PlayAnimByName(hoverOut);
	}
	
	void OnMouseDown(){
		Static.ArmControl.StartCoroutine(Static.ArmControl.PlayBucket());
	}
}
