using UnityEngine;
using System.Collections;
using System.Collections.Generic;

struct RenderState {
	public float angle;
	public Vector3 pos;
	
	public RenderState(float angle, Vector3 pos) {
		this.angle = angle;
		this.pos = pos;
	}
}

public class TreeRenderer : InstructionRenderer {
	public TreeSegment segmentPrefab;
	public TreeSegment stubPrefab;
	public int angleOffset;
	public Vector3 startPos;
	
	public List<Instruction> instructions;
	
	Stack<RenderState> stateStack;
	RenderState state;
	
	List<TreeSegment> segments;
	List<TreeSegment> stubs;
	
	void Start() {
		state = new RenderState(0, startPos);
		stateStack = new Stack<RenderState>();
		stateStack.Push(state);
		segments = new List<TreeSegment>();
		stubs = new List<TreeSegment>();
		
		StartCoroutine<float>(RenderSequence(instructions));
	}
	
	public IEnumerator RenderSequence(List<Instruction> instructionSequence) {	
		stateStack.Push(new RenderState());
		foreach (var instruction in instructionSequence) {
			yield return StartCoroutine<float>(Execute(instruction)); 
			yield return new WaitForSeconds(0.1f);	
		}
	}
	
	IEnumerator Execute(Instruction instruction) {
		if (instruction == Instruction.ccw) {
			yield return StartCoroutine<float>(ExecuteCCW());
		}
		else if (instruction == Instruction.cw) {
			yield return StartCoroutine<float>(ExecuteCW());
		}
		else if (instruction == Instruction.forward) {
			yield return StartCoroutine<float>(ExecuteForward());
		}
		else if (instruction == Instruction.push) {
			ExecutePush();
		}
		else if (instruction == Instruction.pop) {
			ExecutePop();
		}
		yield break;
	}
	
	IEnumerator ExecuteCCW() {
		state.angle += angleOffset;
		yield return StartCoroutine<float>(RenderStub());
		yield break;
	}
	
	IEnumerator ExecuteCW() {
		state.angle -= angleOffset;
		yield return StartCoroutine<float>(RenderStub());
		yield break;
	}
	
	IEnumerator ExecuteForward() {
		var offset = Quaternion.AngleAxis(state.angle, Vector3.forward) * Vector3.up * segmentPrefab.length;
		state.pos += offset;
		yield return StartCoroutine<float>(RenderSegment());
		yield break;
	}
	
	void ExecutePush() {
		stateStack.Push(state);
		state = new RenderState(state.angle, state.pos);
	}
	
	void ExecutePop() {
		state = stateStack.Pop();
	}
	
	IEnumerator RenderStub() {
		stubs.Add(Instantiate(stubPrefab, state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward)) as TreeSegment);
		yield break;	
	}
	
	IEnumerator RenderSegment() {
		segments.Add(Instantiate(segmentPrefab, state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward)) as TreeSegment);
		yield break;
	}
}