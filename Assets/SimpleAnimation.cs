using UnityEngine;
using System.Collections;

public class SimpleAnimation : MonoBehaviour {

	public Animator animator;
	private int current;

	void Awake(){
		if(!animator)
			animator = GetComponent<Animator>();
	}
	public void PlayAnimByName(string name, bool reset = false){
		int stateHash = Animator.StringToHash("Base Layer."+name);
		if(current == stateHash && !reset)
			return;
		current = stateHash;
		animator = animator ?? GetComponent<Animator>();
		animator.GotoState(0,0,stateHash,0);
	}
	public void PauseAnim(){
		animator.speed = 0;
	}
	public void UnPauseAnim(){
		animator.speed = 1;
	}
}
