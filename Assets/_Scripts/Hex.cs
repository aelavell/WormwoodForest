using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {
	public GameObject full;
	public GameObject highlight;
	public Instruction instruction;
	public bool hasInstruction = false;
	
	public void SetInstruction(Instruction instruction) {
		hasInstruction = true;
		this.instruction = instruction;
		full.renderer.material.SetColor("_Out0", Static.InstructionSettings.FindByInstruction(instruction).color);
		full.renderer.material.SetColor("_Out1", Static.InstructionSettings.FindByInstruction(instruction).color);
		full.renderer.material.SetColor("_Out2", Static.InstructionSettings.FindByInstruction(instruction).color);
	}
	
	public IEnumerator ExecuteInstruction() {
		highlight.renderer.material.SetColor("_Out0", Color.blue);	
		yield return StartCoroutine(Static.TreeRenderer.Execute(instruction));
		//highlight.renderer.material.SetColor("_Out1", Color.blue);
		//highlight.renderer.material.SetColor("_Out2", Color.blue);
	}
	
	public IEnumerator BadInstruction() {
		highlight.renderer.material.SetColor("_Out0", Color.red);	
		yield return StartCoroutine(Static.TreeRenderer.Execute(instruction));
		//yield return StartCoroutine(Static.TreeRenderer.Execute(instruction));
		//highlight.renderer.material.SetColor("_Out1", Color.blue);
		//highlight.renderer.material.SetColor("_Out2", Color.blue);
	}
}
