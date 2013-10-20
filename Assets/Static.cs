using UnityEngine;
using System.Collections;

public class Static : MonoBehaviour {

	static Static instance;

	// Use this for initialization
	void Awake () {
		if(!instance){
			instance = this;
		}
		else{
			Destroy (this);
		}
	}

	public ArmControl armControl;
	public static ArmControl ArmControl{
		get{
			return instance.armControl;
		}
	}

	public InstructionSettings instructionSettings;
	public static InstructionSettings InstructionSettings{
		get{
			return instance.instructionSettings;
		}
	}
	
	public TreeRenderer treeRenderer;
	public static TreeRenderer TreeRenderer{
		get{
			return instance.treeRenderer;
		}
	}
	public HexStandHotSpot hexStandHotspot;
	public static HexStandHotSpot HexStandHotspot{
		get{
			return instance.hexStandHotspot;
		}
	}
	
	public Slab slab;
	public static Slab Slab{
		get{
			return instance.slab;
		}
	}
}
