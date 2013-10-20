using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Slab : MonoBehaviour {
	public Splatter splatter;
	public List<RawMaterials> currentMats = new List<RawMaterials>();

	public void AddRawMaterial(RawMaterials rawMat){
		if(!currentMats.Contains(rawMat)){
			currentMats.Add(rawMat);
		}
		var instruct = Static.InstructionSettings.FindByMaterials(currentMats);
		splatter.SetColor(instruct.color);
		splatter.PlaySplat();
	}

	public void Clear(){
		currentMats.Clear();
		splatter.Clear();
	}
}
