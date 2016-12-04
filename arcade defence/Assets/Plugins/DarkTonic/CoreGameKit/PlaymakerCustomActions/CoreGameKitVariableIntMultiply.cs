using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Multiply the value of an int World Variable in Core GameKit")]
public class CoreGameKitVariableIntMultiply : FsmStateAction {
    [RequiredField]
    [Tooltip("World Variable Name")]
	public FsmString worldVariableName = new FsmString(string.Empty);
	
	[RequiredField]
	[Tooltip("The value to multiply the World Variable value by.")]
	public FsmInt newValue = new FsmInt(0);

    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	public override void OnEnter() {
		IntMultiply();
		
		if (!everyFrame) {		
			Finish();
		}
	}
	
	public override void OnUpdate() {
		IntMultiply();
	}
	
	private void IntMultiply() {
		var trans = this.Owner.transform;
		var modifier = new WorldVariableModifier(worldVariableName.Value, WorldVariableTracker.VariableType._integer);
		modifier._modValueIntAmt.curModMode = KillerVariable.ModMode.Mult;
		modifier._modValueIntAmt.Value = newValue.Value;
		
		WorldVariableTracker.ModifyPlayerStat(modifier, trans);
	}
	
	public override void Reset() {
		worldVariableName = new FsmString(string.Empty);
		newValue = new FsmInt(0);
	}
}
