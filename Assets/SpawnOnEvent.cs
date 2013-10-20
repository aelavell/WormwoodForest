using UnityEngine;
using System.Collections;

public class SpawnOnEvent : MonoBehaviour {
	public Transform prefab;
	public Transform spawnLocation;
	// Update is called once per frame
	void SpawnEventOccurred(){
		Instantiate(prefab, spawnLocation.position, spawnLocation.rotation);
	}
}
