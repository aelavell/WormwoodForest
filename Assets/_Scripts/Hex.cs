using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour {
	public GameObject full;
	
	void Start() {
		ToColors(Color.red, Color.green, Color.blue);	
	}
	
	public void ToColors(Color color0, Color color1, Color color2) {
		full.renderer.material.SetColor("_Out0", color0);
		full.renderer.material.SetColor("_Out1", color1);
		full.renderer.material.SetColor("_Out2", color2);
	}
}
