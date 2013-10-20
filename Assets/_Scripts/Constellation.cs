using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constellation : MonoBehaviour {
	public List<Instruction> instructions;
	
	void PushInstruction(Instruction instruction) {
		instructions.Add(instruction);
	}
	
	void Awake() { 
		instructions = new List<Instruction>();
		
		PushInstruction(Instruction.push);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.forward);
		PushInstruction(Instruction.pop);
		PushInstruction(Instruction.ccw);
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
	}
	
}
