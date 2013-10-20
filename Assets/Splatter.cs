using UnityEngine;
using System.Collections;

public class Splatter : MonoBehaviour {

	public void SetColor(Color color){
		foreach(var r in GetComponentsInChildren<Renderer>()){
			r.material.SetColor("Color1",color);
		}
	}

	public void PlaySplat(){

	}

	public void Clear(){

	}
}
