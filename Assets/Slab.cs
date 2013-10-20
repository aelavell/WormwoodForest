using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Slab : MonoBehaviour {
	public Splatter splatter;
	public Renderer fingerGoop;
	public List<RawMaterials> currentMats = new List<RawMaterials>();

	public void AddRawMaterial(RawMaterials rawMat){
		if(!currentMats.Contains(rawMat)){
			currentMats.Add(rawMat);
		}
		var instruct = Static.InstructionSettings.FindByMaterials(currentMats);
		splatter.SetColor(instruct.color);
		splatter.PlaySplat();
	}

	public void SetGoopColor ()
	{
		var instruct = Static.InstructionSettings.FindByMaterials(currentMats);
		fingerGoop.material.SetColor("_Out0",instruct.color);
		fingerGoop.enabled = true;
	}

	public void ClearGoop ()
	{
		fingerGoop.enabled = false;
	}

	public Instruction GetCurrentInstruction ()
	{
		return Static.InstructionSettings.FindByMaterials(currentMats).instruction;
	}

	public void Clear(){
		currentMats.Clear();
		splatter.Clear();
	}
}
