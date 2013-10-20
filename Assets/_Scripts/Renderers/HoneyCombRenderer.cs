using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoneyCombRenderer : InstructionRenderer {
	public GameObject hexPrefab;
	List<Vector3> hexCenters;
	
	public List<Hex> hexes;
	
	void Start() {
		hexCenters = GetHexagonCenters(8.8f, new Vector3(226.6583f, 186,0));
		hexes = new List<Hex>();
		foreach (var center in hexCenters) {
			var hexGO = Instantiate(hexPrefab, center, Quaternion.identity) as GameObject;
			hexes.Add(hexGO.GetComponent<Hex>());
		}
		
		StartCoroutine(Program());
	}
	
	IEnumerator Program() { 
		float wait = 0.05f;
		for (int i = 0; i < 61; i++) {
		hexes[i].SetInstruction(Instruction.forward);
			yield return new WaitForSeconds(wait);
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
