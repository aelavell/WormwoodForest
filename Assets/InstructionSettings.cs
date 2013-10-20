using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class InstructionSettings : MonoBehaviour{
	public List<InstructionGroup> colorGroups;
	
	public InstructionGroup FindByInstruction(Instruction instruct){
		return colorGroups.First(x => x.instruction == instruct);
	}
	
	public InstructionGroup FindByMaterials(List<RawMaterials> materials){
		return colorGroups.Where(x => {
			foreach(var mat in materials){
				if(!x.rawMaterials.Contains(mat)){
					return false;
				}
			}
			return materials.Count == x.rawMaterials.Count;
		}).FirstOrDefault();
	}
}

[System.Serializable]
public class InstructionGroup{
	public List<RawMaterials> rawMaterials;
	public Color color;
	public Instruction instruction;
}