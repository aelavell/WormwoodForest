using UnityEngine;
using UnityEditor;
using System.Collections;

public class Commands {
	[MenuItem("Custom/Toggle Renderer #%t")]
	static void ToggleRenderer(){
		foreach(var go in Selection.gameObjects){
			if(go.renderer)
				go.renderer.enabled = !go.renderer.enabled;
		}
	}
}
