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
	public List<Renderer> toSmash;
	public Renderer babySitting, eyeSitting, eyeStemSitting, beetleSitting;
	public EyeControl eyeControl;
	public BabyControl babyControl;
	public MoveBeetleAfterRandomTime beetleControl;

	public void SetHand(HandType type){
		if(current != null){
			foreach(var r in current.renderers){
				r.enabled = false;
			}
		}
		foreach(var r in hands.Where (x => x.handType == type).Select(x=> x.renderers).First()){
			r.enabled = true;
		}
		current = hands.Where (x => x.handType == type).First ();
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
		foreach(var r in toSmash){
			r.enabled = false;
		}
		slab.AddRawMaterial(queuedMaterial);
		queuedMaterial = RawMaterials.None;
	}

	public void PlaySmash(){
		SetHand(HandType.RockSmash);
		GetComponent<SimpleAnimation>().PlayAnimByName("RockSmash");
	}

	public void BeetleStart(){
		SetHand (HandType.Reaching);
	}

	public void BeetleGrabbed(){
		SetHand (HandType.BeetleHolding);
		beetleControl.Plucked();
	}
	
	public void BeetleDropped(){
		SetHand (HandType.Reaching);
		beetleSitting.enabled = true;
		queuedMaterial = RawMaterials.Beetle;
		toSmash = new List<Renderer>();
		toSmash.Add(beetleSitting);
	}
	
	public void BabyStart(){
		SetHand (HandType.Reaching);
	}

	public void BabyPulled(){
		SetHand (HandType.BabyTurnipPulling);
	}

	public void BabySnatched(){
		SetHand (HandType.BabyTurnipHolding);
		babyControl.StartCoroutine(babyControl.Plucked());
	}

	public void BabyDropped(){
		SetHand (HandType.Reaching);
		babySitting.enabled = true;
		queuedMaterial = RawMaterials.BabyTurnip;
		toSmash = new List<Renderer>();
		toSmash.Add(babySitting);
	}
	
	public void EyeStart(){
		SetHand (HandType.Plucking);
	}
	
	public void EyePlucked(){
		SetHand (HandType.Reaching);
		eyeControl.StartCoroutine(eyeControl.Plucked());
	}

	public void EyeDropped(){
		SetHand (HandType.Reaching);
		eyeSitting.enabled = true;
		eyeStemSitting.enabled = true;
		queuedMaterial = RawMaterials.Eyeball;
		toSmash = new List<Renderer>();
		toSmash.Add(eyeSitting);
		toSmash.Add(eyeStemSitting);
	}	
}

public enum HandType{
	Reaching,
	BabyTurnipPulling,
	BabyTurnipHolding,
	BeetleHolding,
	Plucking,
	RockSmash,
	Poking
}

[System.Serializable]
public class HandRenderersPair{
	public HandType handType;
	public List<Renderer> renderers;
}