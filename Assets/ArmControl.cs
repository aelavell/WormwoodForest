using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ArmControl : MonoBehaviour {

	public Slab slab;
	public List<HandRenderersPair> hands;
	private HandRenderersPair current;
	public SimpleAnimation bucket;
	public float bucketAnimLockTime;
	public RawMaterials queuedMaterial;
	public void SetHand(HandType type){
		if(current != null){
			foreach(var r in current.renderers){
				r.enabled = false;
			}
		}
		foreach(var r in hands.Where (x => x.handType == type).Select(x=> x.renderers).First()){
			r.enabled = true;
		}
	}

	public bool inUse;

	public IEnumerator PlayBucket(){
		while(inUse){
			yield return null;
		}
		inUse = true;
		bucket.PlayAnimByName("BucketSplash");
		yield return new WaitForSeconds(bucketAnimLockTime);
		inUse = false;
	}

	public void RockSmashed(){
		slab.AddRawMaterial(queuedMaterial);
		queuedMaterial = RawMaterials.None;
	}
}

public enum HandType{
	Reaching,
	BabyTurnip,
	Plucking,
	RockSmash,
	Poking
}

[System.Serializable]
public class HandRenderersPair{
	public HandType handType;
	public List<Renderer> renderers;
}