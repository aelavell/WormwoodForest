using UnityEngine;
using System.Collections;

public class Splatter : MonoBehaviour {
	public BucketHotspot bucketHotSpot;
	public HexStandHotSpot hexstandhotSpot;
	public Renderer splat;
	void Start(){
		bucketHotSpot.enabled = false;
		hexstandhotSpot.enabled = false;
	}

	public void SetColor(Color color){
		splat.material.SetColor("_Out0",color);
	}

	public void PlaySplat(){
		splat.enabled = true;
		bucketHotSpot.enabled = true;
		hexstandhotSpot.enabled = true;
	}

	public void Clear(){
		splat.enabled = false;
		bucketHotSpot.enabled = false;
		hexstandhotSpot.enabled = false;
	}
}
