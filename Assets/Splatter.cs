using UnityEngine;
using System.Collections;

public class Splatter : MonoBehaviour {
	public BucketHotspot bucketHotSpot;
	public Renderer splat;
	void Start(){
		bucketHotSpot.enabled = false;
	}

	public void SetColor(Color color){
		foreach(var r in GetComponentsInChildren<Renderer>()){
			r.material.SetColor("Color1",color);
		}
	}

	public void PlaySplat(){
		splat.enabled = true;
		bucketHotSpot.enabled = true;
	}

	public void Clear(){
		splat.enabled = false;
		bucketHotSpot.enabled = false;
	}
}
