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
	public TreeSegment segmentPrefabStatic;
	public TreeSegment stubPrefab;
	public int angleOffset;
	public Vector3 startPos;
	public float length;
	
	Stack<RenderState> stateStack;
	RenderState state;
	
	List<TreeSegment> segments;
	List<TreeSegment> stubs;
	
	void Awake() {
		state = new RenderState(0, startPos);
		stateStack = new Stack<RenderState>();
		stateStack.Push(state);
		segments = new List<TreeSegment>();
		stubs = new List<TreeSegment>();
	}
	
	public IEnumerator Execute(Instruction instruction) {
		if (instruction == Instruction.ccw) {
			yield return StartCoroutine(ExecuteCCW());
		}
		else if (instruction == Instruction.cw) {
			yield return StartCoroutine(ExecuteCW());
		}
		else if (instruction == Instruction.forward) {
			yield return StartCoroutine(ExecuteForward());
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
		
		yield return StartCoroutine(RenderSegment());
		var offset = Quaternion.AngleAxis(state.angle, Vector3.forward) * Vector3.up * length;
		state.pos += offset;
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
		stubs.Add(Instantiate(stubPrefab, transform.position + state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward)) as TreeSegment);
	
		yield break;	
	}
	
	IEnumerator RenderSegment() {
		//Instantiate(segmentPrefab, transform.position + state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward));
		segments.Add(Instantiate(segmentPrefab, transform.position + state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward)) as TreeSegment);
		yield return new WaitForSeconds(.833f);
		//Instantiate(segmentPrefabStatic, transform.position + state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward));
	
		segments.Add(Instantiate(segmentPrefabStatic, transform.position + state.pos, Quaternion.AngleAxis(state.angle, Vector3.forward)) as TreeSegment);
		yield break;
	}
}