using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoneyCombRenderer : InstructionRenderer {
	public GameObject hexPrefab;
	List<Vector3> hexCenters;
	public Constellation constellation;
	
	public AudioClip winSound;
	
	public List<Hex> hexes;
	int hexdex = 0;
	
	bool failed = false;
	
	void Start() {
		hexCenters = GetHexagonCenters(8.8f, new Vector3(226.6583f, 186,0));
		hexes = new List<Hex>();
		foreach (var center in hexCenters) {
			var hexGO = Instantiate(hexPrefab, center, Quaternion.identity) as GameObject;
			hexes.Add(hexGO.GetComponent<Hex>());
		}
		
		StartCoroutine(Program());
	}
	
	void PushInstruction(Instruction instruction) {
		hexes[hexdex].SetInstruction(instruction);
		hexdex++;
	}
	
	IEnumerator Program() { 
		/*
		float wait = 0.05f;
		for (int i = 0; i < 20; i+= 3) {
			hexes[i].SetInstruction(Instruction.forward);
			hexes[i+1].SetInstruction(Instruction.forward);
			hexes[i+2].SetInstruction(Instruction.cw);
		}
		*/
		
		PushInstruction(Instruction.push);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.pop);
		PushInstruction(Instruction.ccw);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.push);
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.pop);
		
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);

		PushInstruction(Instruction.cw);
		
		PushInstruction(Instruction.cw);
		
		PushInstruction(Instruction.push);
		
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.pop);
		
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.forward);
		
		PushInstruction(Instruction.push);
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.cw);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.pop);
		
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.cw);
		
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		
		StartCoroutine(ExecProgram());
		yield break;
	}
	
	IEnumerator ExecProgram() { 
		float wait = 0.833f;
		for (int i = 0; i < 61; i++) {
			if (hexes[i].hasInstruction == false) {
				break;	
			}
			if (hexes[i].instruction != constellation.instructions[i]) {
				failed = true;
				yield return StartCoroutine(hexes[i].BadInstruction());
			}
			else {
				yield return StartCoroutine(hexes[i].ExecuteInstruction());
			}
		}
		
		if (!failed) {
			//audio.PlayOneShot(winSound);
		}

		yield break;
	}
	
	List<Vector3> GetHexagonCenters(float hexLength, Vector3 start) {
		var list = new List<Vector3>();
		
		float modifier = 0.9f;
		var offset0 = Quaternion.AngleAxis(60, Vector3.forward) * Vector3.right * hexLength;
		var offset1 = Quaternion.AngleAxis(-60, Vector3.forward) * Vector3.right * hexLength;
		
		for (int i = 0; i < 5; i++) {
			list.Add(start + 4 * offset0 * modifier  + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 6; i++) {
			list.Add(start + 3 * offset0 * modifier  + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 7; i++) {
			list.Add(start + 2 * offset0 * modifier  + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 8; i++) {
			list.Add(start + offset0 * modifier + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 9; i++) {
			list.Add(start + i * Vector3.right * hexLength);
		}

		for (int i = 0; i < 8; i++) {
			list.Add(start + offset1  * modifier + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 7; i++) {
			list.Add(start + 2 * offset1 * modifier  + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 6; i++) {	
			list.Add(start + 3 * offset1 * modifier  + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 5; i++) {
			list.Add(start + 4 * offset1 * modifier  + i * Vector3.right * hexLength);	
		}
		
		
		return list;
	}
	
	public void ClickHex(int index, Instruction instruction ) {
		hexes[index].SetInstruction(instruction);
	}
}
