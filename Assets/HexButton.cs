using UnityEngine;
using System.Collections;

public class HexButton : MonoBehaviour {

	void OnMouseDown(){
		Debug.Log ("Instruct OnMD");
		if(Static.HexStandHotspot.enabled){
			Debug.Log ("setting Instruct");
			GetComponent<Hex>().SetInstruction(Static.Slab.GetCurrentInstruction());
		}
	}
}
