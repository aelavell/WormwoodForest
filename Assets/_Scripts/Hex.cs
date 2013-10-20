using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {
	public GameObject full;
	public Instruction instruction;
	
	public void SetInstruction(Instruction instruction) {
		this.instruction = instruction;
		full.renderer.material.SetColor("_Out0", Static.InstructionSettings.FindByInstruction(instruction).color);
		full.renderer.material.SetColor("_Out1", Static.InstructionSettings.FindByInstruction(instruction).color);
		full.renderer.material.SetColor("_Out2", Static.InstructionSettings.FindByInstruction(instruction).color);
	}
	
	
}
