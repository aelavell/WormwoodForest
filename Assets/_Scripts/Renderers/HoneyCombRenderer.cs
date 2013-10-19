using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoneyCombRenderer : InstructionRenderer {
	List<Vector3> hexCenters;
	
	void Start() {
		hexCenters = GetHexagonCenters(1.5f, Vector3.zero);	
	}
	
	List<Vector3> GetHexagonCenters(float hexLength, Vector3 start) {
		var list = new List<Vector3>();
		
		for (int i = 0; i < 8; i++) {
			list.Add(start + i * Vector3.right * hexLength);
		}
		
		var offset0 = Quaternion.AngleAxis(60, Vector3.forward) * Vector3.right * hexLength;
		var offset1 = Quaternion.AngleAxis(-60, Vector3.forward) * Vector3.right * hexLength;
		for (int i = 0; i < 7; i++) {
			list.Add(start + offset0 + i * Vector3.right * hexLength);	
			list.Add(start + offset1 + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 6; i++) {
			list.Add(start + 2 * offset0 + i * Vector3.right * hexLength);	
			list.Add(start + 2 * offset1 + i * Vector3.right * hexLength);	
		}
		
		
		for (int i = 0; i < 5; i++) {
			list.Add(start + 3 * offset0 + i * Vector3.right * hexLength);	
			list.Add(start + 3 * offset1 + i * Vector3.right * hexLength);	
		}
		
		for (int i = 0; i < 4; i++) {
			list.Add(start + 4 * offset0 + i * Vector3.right * hexLength);	
			list.Add(start + 4 * offset1 + i * Vector3.right * hexLength);	
		}
		
		return list;
	}
	
	void Update() {
		foreach (var center in hexCenters) {
			Debug.DrawLine (center, center + Vector3.right * .01f);	
		}
	}
}
