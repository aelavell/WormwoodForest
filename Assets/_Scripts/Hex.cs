using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {
	public GameObject full;
	public GameObject highlight;
	public Instruction instruction;
	
	public void SetInstruction(Instruction instruction) {
		this.instruction = instruction;
		full.renderer.material.SetColor("_Out0", Static.InstructionSettings.FindByInstruction(instruction).color);
		full.renderer.material.SetColor("_Out1", Static.InstructionSettings.FindByInstruction(instruction).color);
		full.renderer.material.SetColor("_Out2", Static.InstructionSettings.FindByInstruction(instruction).color);
	}
	
	public void ExecuteInstruction() {
		highlight.renderer.material.SetColor("_Out0", Color.blue);	
		StartCoroutine(Static.TreeRenderer.Execute(instruction));
		//highlight.renderer.material.SetColor("_Out1", Color.blue);
		//highlight.renderer.material.SetColor("_Out2", Color.blue);
	}
}
