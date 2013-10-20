using UnityEngine;
using System.Collections;

public class BabyControl : MonoBehaviour {

	public Renderer normal, empty, closing1, closing2;
	public ArmHotspot hotspot;


	public IEnumerator Plucked(){
		hotspot.enabled = false;
		normal.enabled = false;
		empty.enabled = true;
		yield return new WaitForSeconds(5);
		empty.enabled = false;
		closing1.enabled = true;
		yield return new WaitForSeconds(0.5f);
		closing1.enabled = false;
		closing2.enabled = true;
		yield return new WaitForSeconds(0.1f);
		closing2.enabled = false;
		normal.enabled = true;
		hotspot.enabled = true;
	}
}
